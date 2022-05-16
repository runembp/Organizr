using Organizr.Admin.Data.HelperClasses;
using Organizr.Domain.Entities;

namespace Organizr.Admin.Data.Services;

public class GroupService
{
    private readonly HttpClient _httpClient;

    public GroupService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MemberGroup>> GetAllGroups()
    {
        return await _httpClient.GetFromJsonAsync<List<MemberGroup>>("api/groups") ?? new List<MemberGroup>();
    }
    
    public async Task<MemberGroup?> GetMemberGroupWithMembersById(int groupId)
    {
        return await _httpClient.GetFromJsonAsync<MemberGroup>($"api/groups/{groupId}/members");
    }
    
    public async Task CreateNewGroup(MemberGroup command)
    {
        await _httpClient.PostAsJsonAsync("api/groups/", command);
    }

    public async Task DeleteGroupById(int id)
    {
        await _httpClient.DeleteAsJsonAsync("api/groups", id);
    }

    public async Task<MemberGroup> AddMemberToGroup(int groupId, int memberId)
    {
        var response = await _httpClient.PatchAsJsonAsync($"api/groups/{groupId}/members", memberId);
        return await response.Content.ReadFromJsonAsync<MemberGroup>() ?? new MemberGroup();
    }
    
    public async Task RemoveMemberFromGroup(int groupId, int memberId)
    {
        await _httpClient.DeleteAsJsonAsync($"api/groups/{groupId}", memberId);
    }

    public async Task<MemberGroup> UpdateMemberGroup(MemberGroup group)
    {
        var response = await _httpClient.PatchAsJsonAsync($"api/groups/{group.Id}", group);
        return await response.Content.ReadFromJsonAsync<MemberGroup>() ?? new MemberGroup();
    }
}