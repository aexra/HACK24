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

    public RegisterKeyController(YamlConfigService yamlConfigService, RegisterKeyService registerKeyService)
    {
        _yamlConfigService = yamlConfigService;
        _registerKeyService = registerKeyService;
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
