using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Builder;

namespace Organizr.Application.Services;
public static class KeyVaultService
{
    public static string GetSecret(string keyName, WebApplicationBuilder builder)
    {
        SecretClientOptions options = new SecretClientOptions()
        {
            Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
        };

        var keyVault = builder.Configuration.GetSection("KeyVault:DNS");

        var client = new SecretClient(new Uri(keyVault.Value), new DefaultAzureCredential(), options);
        KeyVaultSecret secret = client.GetSecret(keyName);

        return secret.Value;
    }
}

