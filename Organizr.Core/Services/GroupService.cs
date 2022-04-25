using Organizr.Database;
using Organizr.Infrastructure.Models;

namespace Organizr.Core.Services;

public class GroupService
{
    private readonly OrganizrDataContext _context;

    public GroupService(OrganizrDataContext context)
    {
        _context = context;
    }

    public List<Group> GetGroups()
    {
        return _context.Groups.ToList();
    }

    public Group? GetGroupById(int id)
    {
        return _context.Groups.FirstOrDefault(x => x.GroupId == id);
    } 
}