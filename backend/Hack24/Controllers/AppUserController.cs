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

    public AppUserController(
        UserManager<User> userManager, 
        ITokenService tokenService, 
        RoleManager<IdentityRole> roleManager, 
        SignInManager<User> signInManager, 
        YamlConfigService yamlConfigService,
        RegisterKeyService registerKeyService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _yamlConfigService = yamlConfigService;
        _registerKeyService = registerKeyService;
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> Me()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new ProfileInfoDto
        {
            Id = userId,
            UserName = user.UserName,
            Email = user.Email
        });
    }

    [HttpGet("profile/{id}")]
    [Authorize]
    public async Task<IActionResult> GetProfile([FromRoute] string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new ProfileInfoDto
        {
            Id = id,
            UserName = user.UserName,
            Email = user.Email
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
        return Ok(await _userManager.Users.ToListAsync());
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
            Email = user.Email,
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
                Email = dto.Email,
            };

            // What register key type?
            // Check if dto.RegisterKey is admin RegisterKey
            var settings = await _yamlConfigService.LoadSettingsAsync();
            if (dto.RegisterKey == settings.RegisterKey)
            {
                user.FamilyInviteKey = await _registerKeyService.GenerateFamilyKeyAsync();
            }
            else if (_userManager.Users.Select(u => u.FamilyInviteKey).Contains(dto.RegisterKey))
            {
                user.FamilyInviteKey = null;
            }
            else
            {
                return Unauthorized("Permission denied - registration token is invalid.");
            }

            var createdUser = await _userManager.CreateAsync(user, dto.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(new LoginResponseDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
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
