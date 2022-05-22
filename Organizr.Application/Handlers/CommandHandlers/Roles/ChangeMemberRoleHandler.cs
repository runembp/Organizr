using MediatR;
using Microsoft.AspNetCore.Identity;
using Organizr.Application.Commands.Roles;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses;
using Organizr.Domain.ApplicationConstants;

namespace Organizr.Application.Handlers.CommandHandlers.Roles;

public class ChangeMemberRoleHandler : IRequestHandler<ChangeMemberRoleCommand, ChangeMemberRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ChangeMemberRoleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ChangeMemberRoleResponse> Handle(ChangeMemberRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new ChangeMemberRoleResponse();
        
        var member = await _unitOfWork.MemberRepository.GetByIdAsync(request.MemberId);

        if (member.Id == 0)
        {
            response.Error = "Medlemmet findes ikke";
            return response;
        }

        IdentityResult result;

        switch (request.IsOrganizationAdministrator)
        {
            case false:
                result = await _unitOfWork.UserManager.RemoveFromRoleAsync(member, ApplicationConstants.OrganizationAdministrator); 
                if (!result.Succeeded)
                {
                    response.Error = "Medlemmet kunne ikke fjernes fra Organisationsadministrator rollen";
                    return response;
                }

                break;
            case true:
            {
                result = await _unitOfWork.UserManager.AddToRoleAsync(member, ApplicationConstants.OrganizationAdministrator);
                if (!result.Succeeded)
                {
                    response.Error = "Medlemmet kunne ikke tildeles Organisationsadministrator rollen";
                    return response;
                }

                break;
            }
        }

        response.Succeeded = true;
        return response;
    }
}