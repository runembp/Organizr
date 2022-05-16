using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

namespace Organizr.Admin.Data.Services;

public class ConfigurationService
{
    private readonly HttpClient _httpClient;

    public ConfigurationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Configuration>> GetAllConfigurationsOfType(ConfigType configType)
    {
        return await _httpClient.GetFromJsonAsync<List<Configuration>>($"api/configurations/type/{(int)configType}") ?? new List<Configuration>();
    }

    public async Task<HttpResponseMessage> UpdateConfigurationsOfType(ConfigType configType, List<Configuration> updatedConfigurations)
    {
        return await _httpClient.PostAsJsonAsync($"api/configurations/type/{(int)configType}", updatedConfigurations);
    }
}