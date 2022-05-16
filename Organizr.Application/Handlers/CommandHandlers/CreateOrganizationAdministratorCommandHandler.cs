using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Member;
using Organizr.Domain.ApplicationConstants;
using Organizr.Domain.Entities;


namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateOrganizationAdministratorCommandHandler : IRequestHandler<CreateMemberCommand, CreateMemberResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrganizationAdministratorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateMemberResponse> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        var response = new CreateMemberResponse();
        
        var user = _mapper.Map<Member>(command);

        if (user is null)
        {
            response.Error = "Organisationsadministrator er ikke i et korrekt format";
            return response;
        }
        
        if (!new EmailAddressAttribute().IsValid(command.Email))
        {
            response.Error = "Email er ikke i et korrekt format";
            return response;
        }

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            response.Error = "Organisationsadministrator kunne ikke oprettes";
            return response;
        }

        result = await _unitOfWork.UserManager.AddToRoleAsync(user, ApplicationConstants.OrganizationAdministrator);

        if (!result.Succeeded)
        {
            response.Error = "Organisationsadministrator kunne ikke tildeles rolle";
            return response;
        }

        var createdOrganizationAdministrator = await _unitOfWork.UserManager.FindByEmailAsync(command.Email);

        response.Succeeded = true;
        response.CreatedMember = createdOrganizationAdministrator;
        return response;
    }
}