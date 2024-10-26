using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data.Contexts;

namespace Hack24.Controllers;

[ApiController]
[Route("api/post")]
public class PostController : ControllerBase
{
    private readonly IdentityContext _identityContext;

    public PostController(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllPosts()
    {
        return Ok(await _identityContext.Posts.ToListAsync());
    }

    [HttpPost("{name}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreatePost([FromRoute] string name)
    {
        await _identityContext.Posts.AddAsync(new Data.Models.Post() { Title = name });
        await _identityContext.SaveChangesAsync();

        return Ok(await _identityContext.Posts.ToListAsync());
    }

    [HttpDelete("{name}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePost([FromRoute] string name)
    {
        var post = await _identityContext.Posts.FirstOrDefaultAsync(p => p.Title == name);

        if (post != null)
        {
            _identityContext.Posts.Remove(post);
            await _identityContext.SaveChangesAsync();
            return Ok(await _identityContext.Posts.ToListAsync());
        }
        else
        {
            return NotFound();
        }
    }
}
