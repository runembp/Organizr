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
}