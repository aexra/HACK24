using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Hack24.Data.Contexts;
using Hack24.Data.Models;
using Hack24.DTOs.Solo.Me;

namespace Hack24.Controllers;

[ApiController]
[Route("api/solo")]
public class SoloChallengeController : ControllerBase
{
    private readonly IdentityContext _identityContext;
    private readonly UserManager<User> _userManager;

    public SoloChallengeController(IdentityContext identityContext, UserManager<User> userManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMyChallenges()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.Users.Include(u => u.Post).FirstAsync(u => u.Id == userId);

        var accepted = await _identityContext.AcceptedSoloChallenges.Where(c => c.User == user)
            .Include(c => c.SoloChallenge)
            .Include(c => c.SoloChallenge.SoloChallengeCatalog)
            .Include(c => c.SoloChallenge.SoloChallengeCatalog.ChallengeType)
            .ToListAsync();
        var completed = await _identityContext.CompletedSoloChallenges.Where(c => c.User == user)
            .Include(c => c.SoloChallenge)
            .Include(c => c.SoloChallenge.SoloChallengeCatalog)
            .Include(c => c.SoloChallenge.SoloChallengeCatalog.ChallengeType)
            .ToListAsync();

        var counters = new Dictionary<string, int>();

        foreach (var c in completed)
        {
            var type = c.SoloChallenge.SoloChallengeCatalog.ChallengeType.Name;
            if (counters.ContainsKey(type))
            {
                counters[type]++;
            }
            else
            {
                counters.Add(type, 1);
            }
        }

        return Ok(new MyChallengesDto()
        {
            Accepted = accepted,
            Completed = completed,
            Counters = counters
        });
    }
}
