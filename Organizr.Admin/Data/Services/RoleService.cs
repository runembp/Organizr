using Organizr.Admin.Data.HelperClasses;

namespace Organizr.Admin.Data.Services;

public class RoleService
{
    private readonly HttpClient _httpClient;

    public RoleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> IsUserOrganizationAdministrator(int memberId)
    {
        var result = await _httpClient.GetFromJsonAsync<bool>($"api/roles/{memberId}");
        return result;
    }

    public async Task<bool> UpdateMemberRole(int memberId, bool setUserOrganizationAdministrator)
    {
        var result = await _httpClient.PatchAsJsonAsync($"api/roles/{memberId}", setUserOrganizationAdministrator);
        return result.IsSuccessStatusCode;
    }
}