using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Organizr.Application.Services;
public static class KeyVaultService
{
    private const string KeyValuePair = "KeyVault:DNS";
    private const string KeyName = "JwtKey";

    public static async Task<string> GetSecretFromBuilder(WebApplicationBuilder builder)
    {
        var keyVaultUri = builder.Configuration.GetSection(KeyValuePair).Value;

        return await GetSecret(keyVaultUri);
    }

    public static async Task<string> GetSecretFromConfig(IConfiguration config)
    {
        var keyVaultUri = config.GetSection(KeyValuePair).Value;

        return await GetSecret(keyVaultUri);
    }

    private static async Task<string> GetSecret(string keyVaultUri)
    {
        var keyVaultSecretOptions = new SecretClientOptions
        {
            Retry =
            {
                Delay= TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(16),
                MaxRetries = 5,
                Mode = RetryMode.Exponential
            }
        };

        var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential(), keyVaultSecretOptions);
        KeyVaultSecret secret = await client.GetSecretAsync(KeyName);

        return secret.Value;
    }
}

