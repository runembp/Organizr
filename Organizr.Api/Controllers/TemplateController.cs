﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Queries;
using Organizr.Application.Services;
using Organizr.Core.Entities;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/template")]
[Obsolete("Proof of concept - to be deleted")]
public class TemplateController : ControllerBase
{
    private readonly AccountService _accountService;

    public TemplateController(AccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost("login-with-predetermined-user-and-password-without-roles")]
    public async Task<IActionResult> LoginWithPredeterminedUserAndPassword()
    {
        var request = new LoginUserQuery()
        {
            Email = "user@organizr.com",
            Password = "Tester1+"
        };
        
        var result = await _accountService.Login(request);

        if (!result.Succeeded)
        {
            return BadRequest("Failed login");
        }

        return Ok(result);
    }
    
    [HttpPost("login-with-predetermined-user-and-password_with_organisationadministrator_role")]
    public async Task<IActionResult> LoginWithPredeterminedUserAndPassword_2()
    {
        var request = new LoginUserQuery()
        {
            Email = "organizationadministrator@organizr.com",
            Password = "Orgadmin1+"
        };
        
        var result = await _accountService.Login(request);

        if (!result.Succeeded)
        {
            return BadRequest("Failed login");
        }

        return Ok(result);
    }
    
    [HttpGet("TestAuth-OnlyForAuthorized")]
    [Authorize]
    public IActionResult Test()
    {
        return Ok("If you see this, you're authorized! Which means, you just have to be logged in, not necessarily have a membership in any group");
    }

    [HttpGet("TestAuth-OnlyForOrganizationAdministrators")]
    [Authorize(Roles = OrganizrRole.OrganizationAdministrator)]
    public IActionResult TestOrgAdministrator()
    {
        return Ok("If you see this, you're authorised as an Organization administrator!");
    }

    [HttpGet("TestAuth-OnlyForAdministrators")]
    [Authorize(Roles = OrganizrRole.Administrator)]
    public IActionResult TestAdministrator()
    {
        return Ok("If you see this, you're authorised as an Administrator!");
    }
    
    [HttpGet("TestAuth-OnlyForBasic")]
    [Authorize(Roles = OrganizrRole.Basic)]
    public IActionResult TestBasic()
    {
        return Ok("If you see this, you're authorised as a member with a Basic-Role!");
    }
    
    [HttpGet("TestAuth-OnlyForAnyRolesAuthenticated")]
    [Authorize(Roles = OrganizrRole.Basic + "," + OrganizrRole.Administrator + "," + OrganizrRole.OrganizationAdministrator)]
    public IActionResult TestAuthenticatedWithAnyRole()
    {
        return Ok("If you see this, you're authorised as a member with any Role!");
    }
}