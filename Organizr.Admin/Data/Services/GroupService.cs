using System.Net;
using Organizr.Admin.HelperClasses;
using Organizr.Domain.Entities;

namespace Organizr.Admin.Data.Services;

public class GroupService
{
    private readonly HttpClient _httpClient;

    public GroupService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MemberGroup>?> GetAllGroups()
    {
        return await _httpClient.GetFromJsonAsync<List<MemberGroup>>("api/groups");
    }
    
    public async Task<MemberGroup?> GetMemberGroupWithMembersById(int groupId)
    {
        return await _httpClient.GetFromJsonAsync<MemberGroup>($"api/groups/{groupId}/members");
    }
    
    public async Task<MemberGroup?> CreateNewGroup(MemberGroup command)
    {
        var response = await _httpClient.PostAsJsonAsync("api/groups/", command);
        return await response.Content.ReadFromJsonAsync<MemberGroup>();
    }

    public async Task<HttpStatusCode> DeleteGroupById(int id)
    {
        var response = await _httpClient.DeleteAsJsonAsync("api/groups", id);
        return response.StatusCode;
    }

    public async Task<bool> AddMemberToGroup(int groupId, int memberId)
    {
        var response = await _httpClient.PatchAsJsonAsync($"api/groups/{groupId}/members", memberId);
        return response.IsSuccessStatusCode;
    }
    
    public async Task<bool> RemoveMemberFromGroup(int groupId, int memberId)
    {
        var response = await _httpClient.DeleteAsJsonAsync($"api/groups/{groupId}", memberId);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateMemberGroup(MemberGroup group)
    {
        var response = await _httpClient.PatchAsJsonAsync($"api/groups/{group.Id}", group);
        return response.IsSuccessStatusCode;
    }
}