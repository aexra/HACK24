﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Hack24.Data.Contexts;
using Hack24.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Hack24.DTOs.Teams;
using Hack24.DTOs.Teams.challenge;

namespace Hack24.Controllers;

[ApiController]
[Route("api/teams")]
public class TeamController : ControllerBase
{
    private readonly IdentityContext _identityContext;
    private readonly UserManager<User> _userManager;

    public TeamController(IdentityContext identityContext, UserManager<User> userManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        var type = await _identityContext.TeamTypes.FindAsync(dto.TypeId);

        if (type == null)
        {
            return NotFound();
        }

        var team = new Team()
        {
            Name = dto.Name,
            Type = type,
        };

        await _identityContext.Teams.AddAsync(team);

        var ut = new UserTeam()
        {
            Team = team,
            User = user
        };

        await _identityContext.UserTeams.AddAsync(ut);

        await _identityContext.SaveChangesAsync();

        return Ok(team);
    }

    [HttpPost("join/{teamId}")]
    [Authorize]
    public async Task<IActionResult> JoinTeam([FromRoute] int teamId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.Users
            .Include(u => u.UserTeam)
            .FirstAsync(u => u.Id == userId);

        if (user.UserTeam != null)
        {
            return BadRequest("User is already in team");
        }

        if (await _identityContext.Teams.FindAsync(teamId) == null)
        {
            return NotFound();
        }

        var userteam = new UserTeam() { UserId = user.Id, TeamId = teamId };

        await _identityContext.UserTeams.AddAsync(userteam);
        await _identityContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var teams = await _identityContext.Teams
            .Include(t => t.Type)
            .Include(t => t.UserTeams)
            //.Include(t => t.AcceptedChallenges)
            //.Include(t => t.CompletedChallenges)
            .ToListAsync();

        var dtos = teams.Select(t => new TeamDto() 
        { 
            Id = t.Id, 
            Name = t.Name,
            Type = t.Type,
            Members = t.UserTeams.Select(ut => ut.User),
            //AcceptedChallenges = t.AcceptedChallenges.Select(ac => ac.TeamChallenge).ToList(),
            //CompletedChallenges = t.CompletedChallenges.Select(cc => cc.TeamChallenge).ToList(),
            //CompleteRequests = t.CompleteRequests
        });

        return Ok(dtos);
    }

    [HttpGet("{teamId}")]
    [Authorize]
    public async Task<IActionResult> GetTeamFull([FromRoute] int teamId)
    {
        var team = await _identityContext.Teams
            .Include(t => t.Type)
            .Include(t => t.UserTeams)
            .Include(t => t.AcceptedChallenges)
            .Include(t => t.CompletedChallenges)
            .FirstAsync(t => t.Id == teamId);

        return Ok(new TeamDto()
        {
            Id = team.Id,
            Name = team.Name,
            Type = team.Type,
            Members = team.UserTeams.Select(ut => ut.User),
            AcceptedChallenges = team.AcceptedChallenges.Select(ac => ac.TeamChallenge).ToList(),
            CompletedChallenges = team.CompletedChallenges.Select(cc => cc.TeamChallenge).ToList(),
            //CompleteRequests = t.CompleteRequests
        });
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMyTeam()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.Users
            .Include(u => u.UserTeam)
            .FirstAsync(u => u.Id == userId);

        if (user.UserTeam == null)
        {
            return NotFound();
        }

        var team = (await _identityContext.Teams
            .Include(t => t.Type)
            .Include(t => t.UserTeams)
            .Include(t => t.AcceptedChallenges)
            .Include(t => t.CompletedChallenges)
            .ToListAsync()).Find(u => u.Id == user.UserTeam.TeamId);

        return Ok(new TeamDto()
        {
            Id = team.Id,
            Name = team.Name,
            Type = team.Type,
            Members = team.UserTeams.Select(ut => ut.User),
            AcceptedChallenges = team.AcceptedChallenges.Select(ac => ac.TeamChallenge).ToList(),
            CompletedChallenges = team.CompletedChallenges.Select(cc => cc.TeamChallenge).ToList(),
            //CompleteRequests = t.CompleteRequests
        });
    }

    [HttpPost("challenge")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateChallenge([FromBody] CreateTeamChallengeDto createTeamChallengeDto)
    {
        if (_identityContext.TeamChallengeCatalogs.Find(createTeamChallengeDto.TeamChallengeCatalogId) == null)
        {
            return NotFound();
        }

        var ch = new TeamChallenge()
        {
            Start = createTeamChallengeDto.Start,
            End = createTeamChallengeDto.End,
            TeamChallengeCatalogId = createTeamChallengeDto.TeamChallengeCatalogId,
        };

        await _identityContext.TeamChallenges.AddAsync(ch);

        await _identityContext.SaveChangesAsync();
        
        return Ok(ch);
    }
}
