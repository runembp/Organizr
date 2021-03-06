using Newtonsoft.Json.Linq;
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

    public async Task<Member> GetMemberById(int userId)
    {
        return await _httpClient.GetFromJsonAsync<Member>($"api/members/{userId}") ?? new Member();
    }
    
    public async Task<Member> GetMemberWithMembershipsById(int memberId)
    {
        return await _httpClient.GetFromJsonAsync<Member>($"/api/members/{memberId}/memberships") ?? new Member();
    }
    
    public async Task<List<Member>> GetAllMembers()
    {
        return await _httpClient.GetFromJsonAsync<List<Member>>($"api/members") ?? new List<Member>();
    }

    public async Task<List<Member>> GetAllMembersWithNoMembershipOfGroup(int groupId)
    {
        return await _httpClient.GetFromJsonAsync<List<Member>>($"api/members?hasMembership=false&groupId={groupId}") ?? new List<Member>();
    }

    public async Task<Member?> PostNewMember(object command)
    {
        var response = await _httpClient.PostAsJsonAsync("api/members", command);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadAsStringAsync();

        return JObject.Parse(result)["createdMember"]?.ToObject<Member>();
    }

    public async Task<bool> UpdateMember(Member member)
    {
        var result = await _httpClient.PatchAsJsonAsync($"/api/members/{member.Id}", member);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteMember(Member memberToDelete)
    {
        var result = await _httpClient.DeleteAsJsonAsync($"api/members/{memberToDelete.Id}");
        return result.IsSuccessStatusCode;
    }

    public async Task<List<MemberGroup>> GetAllGroupsMemberIsNotMemberOf(int memberId)
    {
        return await _httpClient.GetFromJsonAsync<List<MemberGroup>>($"api/groups/no-membership/{memberId}") ?? new List<MemberGroup>();
    }
}