using Organizr.Admin.Data.HelperClasses;
using Organizr.Domain.Entities;

namespace Organizr.Admin.Data.Services;

public class MemberService
{
    private readonly HttpClient _httpClient;

    public MemberService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Member>> GetAllMembers()
    {
        return await _httpClient.GetFromJsonAsync<List<Member>>("api/members") ?? new List<Member>();
    }

    public async Task<Member?> PostNewMember(object command)
    {
        var response = await _httpClient.PostAsJsonAsync("api/members", command);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var member = await response.Content.ReadFromJsonAsync<Member>();
        
        return member;
    }

    public async Task<Member> GetMemberWithGroupsById(int memberId)
    {
        return await _httpClient.GetFromJsonAsync<Member>($"/api/members/{memberId}/groups") ?? new Member();
    }

    public async Task<bool> UpdateMember(Member member)
    {
        var result = await _httpClient.PatchAsJsonAsync($"/api/members/{member.Id}", member);
        return result.IsSuccessStatusCode;
    }
}