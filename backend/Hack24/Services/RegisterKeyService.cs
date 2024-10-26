namespace Hack24.Services;
public class RegisterKeyService
{
    private readonly YamlConfigService _yamlConfigService;

    public RegisterKeyService(YamlConfigService yamlConfigService)
    {
        _yamlConfigService = yamlConfigService;
    }

    public async Task<string> GenerateFamilyKeyAsync()
    {
        // Creating object of random class 
        var rand = new Random();

        // Choosing the size of string 
        // Using Next() string 
        var stringlen = (await _yamlConfigService.LoadSettingsAsync()).RegisterKeyLen;
        var str = "";
        for (int i = 0; i < stringlen; i++)
        {
            // Generating a random number. 
            var randValue = rand.Next(0, 26);

            // Generating random character by converting 
            // the random number into character. 
            var letter = Convert.ToChar(randValue + 65);

            // Appending the letter to string. 
            str += letter;
        }

        return str;
    }
}
