using Hack24.Data.Contexts;
using Hack24.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hack24.Controllers;

[ApiController]
[Route("api/key")]
public class RegisterKeyController : ControllerBase
{
    private readonly YamlConfigService _yamlConfigService;
    private readonly RegisterKeyService _registerKeyService;
    private readonly IdentityContext _identityContext;

    public RegisterKeyController(YamlConfigService yamlConfigService, RegisterKeyService registerKeyService, IdentityContext identityContext)
    {
        _yamlConfigService = yamlConfigService;
        _registerKeyService = registerKeyService;
        _identityContext = identityContext;
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> CheckKey([FromRoute] string key)
    {
        if (key == _yamlConfigService.Settings.RegisterKey || _identityContext.Users.Select(u => u.FamilyInviteKey).Contains(key))
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetKey()
    {
        return Ok(_yamlConfigService.Settings.RegisterKey);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RegenerateKey()
    {
        var settings = await _yamlConfigService.LoadSettingsAsync();

        var key = await _registerKeyService.GenerateFamilyKeyAsync();

        settings.RegisterKey = key;

        await _yamlConfigService.SaveSettingsAsync(settings);

        return Ok(_yamlConfigService.Settings.RegisterKey);
    }

    [HttpPut("{key}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetKey([FromRoute] string key)
    {
        var settings = await _yamlConfigService.LoadSettingsAsync();

        settings.RegisterKey = key;

        await _yamlConfigService.SaveSettingsAsync(settings);

        return Ok(_yamlConfigService.Settings.RegisterKey);
    }
}
