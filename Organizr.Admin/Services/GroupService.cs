using Organizr.Domain.ApplicationConstants;
using Organizr.Domain.Entities;

namespace Organizr.Admin.Services;

public class GroupService
{
    private readonly HttpClient _httpClient;

    public GroupService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MemberGroup>> GetAllGroups()
    {
        // return await _httpClient.GetFromJsonAsync<List<MemberGroup>>(ApiEndpoints.GetAllGroups) ?? new List<MemberGroup>();
        return new List<MemberGroup>();
    }

    public async Task DeleteGroupById(int id)
    {
        // await _httpClient.DeleteAsJsonAsync(ApiEndpoints.DeleteGroupById, id);
    }

    public async Task RemoveMemberFromGroup(int groupId, int memberId)
    {
        // await _httpClient.DeleteAsJsonAsync(ApiEndpoints.RemoveMemberFromGroup, memberId);
    }

    public async Task<MemberGroup> AddMemberToGroup(int groupId, int selectedMemberId)
    {
        // var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.AddMemberToGroup, selectedMemberId);
        // return await response.Content.ReadFromJsonAsync<MemberGroup>() ?? new MemberGroup();
        return new MemberGroup();
    }

    public async Task<List<MemberGroup>> UpdateMemberGroup(int groupId, string groupNameTextEdit, bool groupIsOpenCheckbox)
    {
        var content = (Name: groupNameTextEdit, IsOpen: groupIsOpenCheckbox);
        // var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.UpdateMemberGroup, content);
        // return await response.Content.ReadFromJsonAsync<MemberGroup>() ?? new MemberGroup();
        return new List<MemberGroup>();
    }

    public async Task<MemberGroup?> GetMemberGroupWithMembersById(int groupId)
    {
        // return await _httpClient.GetFromJsonAsync<MemberGroup>(ApiEndpoints.GetMemberGroupWithMembersById);
        return new MemberGroup();
    }
    

    public async Task CreateNewGroup(string groupName, bool isOpen)
    {
        var command = (GroupName: groupName, IsOpen: isOpen);
        // await _httpClient.PostAsJsonAsync(ApiEndpoints.PostNewGroup, command);
    }
}