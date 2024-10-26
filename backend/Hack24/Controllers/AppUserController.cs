using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data.Models;
using Web.Interfaces;
using Microsoft.EntityFrameworkCore;

using DataAccess.DTOs;
using System.Security.Claims;
using Hack24.Services;

namespace Web.Controllers;

[ApiController]
[Route("api/user")]
public class AppUserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly YamlConfigService _yamlConfigService;
    private readonly RegisterKeyService _registerKeyService;
    private readonly UserRoleService _userRoleService;

    public AppUserController(
        UserManager<User> userManager, 
        ITokenService tokenService, 
        RoleManager<IdentityRole> roleManager, 
        SignInManager<User> signInManager, 
        YamlConfigService yamlConfigService,
        RegisterKeyService registerKeyService,
        UserRoleService userRoleService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _yamlConfigService = yamlConfigService;
        _registerKeyService = registerKeyService;
        _userRoleService = userRoleService;
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> Me()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.Users.Include(u => u.Post).FirstAsync(u => u.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new ProfileInfoDto
        {
            Id = userId,
            UserName = user.UserName,
            Email = user.Email,
            Image = user.Image,
            Bio = user.Bio,
            Hobby = user.Hobby,
            Pets = user.Pets,
            FamilyInviteKey = user.FamilyInviteKey,
            Telegram = user.Telegram,
            VK = user.VK,
            Post = new DataAccess.DTOs.Post.PostDto()
            {
                Id = user.Post.Id,
                Title = user.Post.Title,
            }
        });
    }

    [HttpGet("profile/{id}")]
    [Authorize]
    public async Task<IActionResult> GetProfile([FromRoute] string id)
    {
        var user = await _userManager.Users.Include(u => u.Post).FirstAsync(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new ProfileInfoDto
        {
            Id = id,
            UserName = user.UserName,
            Email = user.Email,
            Image = user.Image,
            Bio = user.Bio,
            Hobby = user.Hobby,
            Pets = user.Pets,
            FamilyInviteKey = user.FamilyInviteKey,
            Telegram = user.Telegram,
            VK = user.VK,
            Post = new DataAccess.DTOs.Post.PostDto()
            {
                Id = user.Post.Id,
                Title = user.Post.Title,
            }
        });
    }

    [HttpGet("check")]
    [Authorize]
    public async Task<IActionResult> CheckLogin()
    {
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userManager.Users.Include(u => u.Post).ToListAsync());
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAll()
    {
        foreach (var user in await _userManager.Users.ToListAsync())
        {
            await _userManager.DeleteAsync(user);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{username}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByName([FromRoute] string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpDelete]
    [Route("{username}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteByName([FromRoute] string username)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

        if (user == null)
        {
            return NotFound();
        }

        await _userManager.DeleteAsync(user);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);
        
        if (user == null)
        {
            return Unauthorized("Invalid username");
        }

        var result = _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.IsCompletedSuccessfully) return Unauthorized("Username not found and/or password incorrect");
        
        return Ok(new LoginResponseDto()
        {
            UserName = user.UserName,
            Token = await _tokenService.CreateToken(user),
            FamilyInviteKey = user.FamilyInviteKey,
            Id = user.Id
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new User
            {
                UserName = dto.UserName,
            };

            var createdUser = await _userManager.CreateAsync(user, dto.Password);
            
            // What register key type?
            // Check if dto.RegisterKey is admin RegisterKey
            var settings = await _yamlConfigService.LoadSettingsAsync();
            if (dto.RegisterKey == settings.RegisterKey)
            {
                // Регистрация по ключу администратора
                user.FamilyInviteKey = await _registerKeyService.GenerateFamilyKeyAsync();
                await _userRoleService.AddToRolesAsync(user, "Employee");
            }
            else if (_userManager.Users.Select(u => u.FamilyInviteKey).Contains(dto.RegisterKey))
            {
                // Регистрация по приглашению члена семьи
                user.FamilyInviteKey = null;
                await _userRoleService.AddToRolesAsync(user, "FamilyMember");
            }
            else
            {
                // Невалидный ключ
                return Unauthorized("Access denied - registration token is invalid.");
            }

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(new LoginResponseDto
                    {
                        UserName = user.UserName,
                        FamilyInviteKey = user.FamilyInviteKey,
                        Token = await _tokenService.CreateToken(user)
                    });
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
