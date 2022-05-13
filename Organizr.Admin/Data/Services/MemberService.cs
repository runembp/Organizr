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
        var member = await response.Content.ReadFromJsonAsync<Member>();
        return member;
    }
}