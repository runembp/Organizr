using Organizr.Admin.Data.DTO;
using Organizr.Admin.Data.HelperClasses;
using Organizr.Domain.Entities;

namespace Organizr.Admin.Data.Services;

public class MembershipService
{
    private readonly HttpClient _httpClient;

    public MembershipService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Membership>> GetMembershipsForMember(int memberId)
    {
        return await _httpClient.GetFromJsonAsync<List<Membership>>($"api/memberships/members/{memberId}") ?? new List<Membership>();
    }

    public async Task<Membership?> AddMembership(int groupId, int memberId, int roleId)
    {
        var request = new MembershipDTO
        {
            GroupId = groupId,
            MemberId = memberId,
            RoleId = roleId
        };
        
        var response = await _httpClient.PostAsJsonAsync("api/memberships", request);
        return await response.Content.ReadFromJsonAsync<Membership>();
    }

    public async Task<bool> RemoveMembership(int memberId)
    {
        var result = await _httpClient.DeleteAsJsonAsync($"api/memberships/members/{memberId}");
        return result.IsSuccessStatusCode;
    }
}