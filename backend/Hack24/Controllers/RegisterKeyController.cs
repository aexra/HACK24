using Hack24.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hack24.Controllers;

[ApiController]
[Route("api/key")]
public class RegisterKeyController : ControllerBase
{
    private readonly YamlConfigService _yamlConfigService;

    public RegisterKeyController(YamlConfigService yamlConfigService)
    {
        _yamlConfigService = yamlConfigService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetKey()
    {
        return Ok(_yamlConfigService.Settings.RegisterKey);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RegenerateKey()
    {
        // TODO: Keygen
        return Ok();
    }

    [HttpPost("{key}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetKey([FromRoute] string key)
    {
        var settings = await _yamlConfigService.LoadSettingsAsync();

        settings.RegisterKey = key;

        await _yamlConfigService.SaveSettingsAsync(settings);

        return Ok(_yamlConfigService.Settings.RegisterKey);
    }
}
