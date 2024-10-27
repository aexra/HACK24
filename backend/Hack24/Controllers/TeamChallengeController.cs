﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Hack24.Data.Contexts;
using Hack24.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Hack24.DTOs.Teams;

namespace Hack24.Controllers;

[ApiController]
[Route("api/team")]
public class TeamChallengeController : ControllerBase
{
    private readonly IdentityContext _identityContext;
    private readonly UserManager<User> _userManager;

    public TeamChallengeController(IdentityContext identityContext, UserManager<User> userManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
    }

    [HttpGet("all")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var teams = await _identityContext.Teams
            .Include(t => t.Type)
            .Include(t => t.UserTeams)
            .Include(t => t.AcceptedChallenges)
            .Include(t => t.CompletedChallenges)
            .ToListAsync();

        var dtos = teams.Select(t => new TeamDto() 
        { 
            Id = t.Id, 
            Name = t.Name,
            Type = t.Type,
            Members = t.UserTeams.Select(ut => ut.User),
            AcceptedChallenges = t.AcceptedChallenges.Select(ac => ac.TeamChallenge).ToList(),
            CompletedChallenges = t.CompletedChallenges.Select(cc => cc.TeamChallenge).ToList(),
            //CompleteRequests = t.CompleteRequests
        });

        return Ok(dtos);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetMyTeam()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.Users
            .Include(u => u.Post)
            .Include(u => u.UserTeam)
            .Include(u => u.UserTeam.Team)
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

        var members = team.UserTeams.Select(ut => ut.User);

        return Ok(new TeamDto()
        {
            Id = team.Id,
            Name = team.Name,
            Type = team.Type,
            Members = members,
            AcceptedChallenges = team.AcceptedChallenges.Select(ac => ac.TeamChallenge).ToList(),
            CompletedChallenges = team.CompletedChallenges.Select(cc => cc.TeamChallenge).ToList(),
            //CompleteRequests = t.CompleteRequests
        });
    }
}
