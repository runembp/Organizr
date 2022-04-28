using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Queries;
using Organizr.Application.Services;
using Organizr.Infrastructure.DTO;

namespace Organizr.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AuthController(AccountService accountService)
        {
            _accountService = accountService;
        }
    
        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> Login([FromBody] LoginUserQuery query)
        {
            var result = await _accountService.Login(query);

            if (!result.Succeeded)
            {
                return BadRequest("Failed login");
            }

            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            //TODO Implement this.
            return BadRequest("Not yet implemented");
        }
    
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            //TODO Implement this.
            return BadRequest("Not yet implemented");
        }
    }
}