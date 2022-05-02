using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Services;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly AccountService _accountService;
    public UserController(AccountService accountService)
    {
        _accountService = accountService;
    }
}