using Organizr.Domain.ApplicationConstants;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

namespace Organizr.Admin.Services;

public class ConfigurationService
{
    private readonly HttpClient _httpClient;

    public ConfigurationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Configuration>> GetAllConfigurationsOfType(ConfigType pageSetup)
    {
        // await _httpClient.GetFromJsonAsync<List<Configuration>>(ApiEndpoints.GetAllConfigurationsOfType) ?? new List<Configuration>();

        return new List<Configuration>();
    }

    public async Task UpdateConfigurationsOfTypePageSetup(object command)
    {
        // await _httpClient.PostAsJsonAsync(ApiEndpoints.UpdateConfigurationsOfTypePageSetup, command);
    }

    public async Task UpdateConfigurationsOfTypeCssSetup(string cssStringValue)
    {
        // await _httpClient.PostAsJsonAsync(ApiEndpoints.UpdateConfigurationsOfTypeCssSetup, cssStringValue);
    }

    public async Task UpdateConfigurationsOfTypeConfiguration(object command)
    {
        // await _httpClient.PostAsJsonAsync(ApiEndpoints.UpdateConfigurationsOfTypeConfiguration, command);
    }
}