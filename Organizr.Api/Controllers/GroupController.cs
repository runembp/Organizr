using Microsoft.AspNetCore.Mvc;
using Organizr.Core.Services;
using Organizr.Infrastructure.Models;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly GroupService _groupService;
    
    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }
    
    [HttpGet("AllGroups")]
    public ActionResult<List<Group>> GetAllGroups()
    {
        return _groupService.GetGroups();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Group> GetGroupById(int id)
    {
        var group = _groupService.GetGroupById(id);

        if (group is null)
        {
            return NotFound(404);
        }

        return group;
    }
}