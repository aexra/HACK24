﻿using YamlDotNet.Serialization;

namespace Hack24.Services;

public class AppSettings
{
    public string RegisterKey { get; set; }
    public int RegisterKeyLen { get; set; }
}

public class YamlConfigService
{
    private readonly string _filePath = "appsettings.yml";

    public AppSettings Settings => LoadSettingsAsync().Result;

    public async Task<AppSettings> LoadSettingsAsync()
    {
        using (var reader = new StreamReader(_filePath))
        {
            var yaml = await reader.ReadToEndAsync();
            var deserializer = new DeserializerBuilder().Build();
            return deserializer.Deserialize<AppSettings>(yaml);
        }
    }

    public async Task SaveSettingsAsync(AppSettings settings)
    {
        var serializer = new SerializerBuilder().JsonCompatible().Build();
        var yaml = serializer.Serialize(settings);
        await File.WriteAllTextAsync(_filePath, yaml);
    }
}