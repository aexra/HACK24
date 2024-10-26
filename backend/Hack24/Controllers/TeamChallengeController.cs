using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Hack24.Data.Contexts;
using Hack24.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Hack24.DTOs.Teams.Me;
using Microsoft.AspNetCore.Authorization;

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

        //var teamId = user.Team.Id;
        var team = (await _identityContext.Teams
            .Include(t => t.Type)
            .Include(t => t.UserTeams)
            .ToListAsync()).Find(u => u.Id == user.UserTeam.TeamId);

        var members = team.UserTeams.Select(ut => ut.User);

        return Ok(new MyTeamDto()
        {
            Accepted = team.AcceptedChallenges,
            Completed = team.CompletedChallenges,
            Team = team,
            Members = members
        });
    }
}
