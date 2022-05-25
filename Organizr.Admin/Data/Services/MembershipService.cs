using Newtonsoft.Json.Linq;
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
        return await _httpClient.GetFromJsonAsync<List<Membership>>($"api/memberships?memberId={memberId}") ?? new List<Membership>();
    }

    public async Task<Membership?> AddMembership(int groupId, int memberId, int roleId)
    {
        var command = new MembershipDTO
        {
            GroupId = groupId,
            MemberId = memberId,
            RoleId = roleId
        };
        
        var response = await _httpClient.PostAsJsonAsync("api/memberships", command);

        var result = await response.Content.ReadAsStringAsync();

        return JObject.Parse(result)["createdMembership"]?.ToObject<Membership>();
    }

    public async Task<bool> RemoveMembership(int membershipId)
    {
        var result = await _httpClient.DeleteAsJsonAsync($"api/memberships/{membershipId}");
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> ChangeRoleInMembership(int roleId, int membershipId)
    {
        var command = new MembershipRoleDTO
        {
            MembershipId = membershipId,
            RoleId = roleId
        };
        
        var response = await _httpClient.PatchAsJsonAsync($"api/memberships/{membershipId}", command);
        return response.IsSuccessStatusCode;
    }
}