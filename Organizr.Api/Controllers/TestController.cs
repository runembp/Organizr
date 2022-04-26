using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("TestAuth")]
    [Authorize]
    public IActionResult Test()
    {
        return Ok("If you see this, you're authorized!");
    } 
}