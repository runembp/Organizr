using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Organizr.Application.Commands;
using Organizr.Application.Responses;
using Organizr.Core.ApplicationConstants;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateOrganizationAdministratorCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrganizationAdministratorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<OrganizrUser>(command);

        var response = new CreateUserResponse {Succeeded = false};

        if (user is null)
        {
            return response;
        }

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            response.Succeeded = result.Succeeded;
            response.Errors = result.Errors.ToList();
            return response;
        }

        result = await _unitOfWork.UserManager.AddToRoleAsync(user, ApplicationConstants.OrganizationAdministrator);

        if (!result.Succeeded)
        {
            response.Succeeded = result.Succeeded;
            response.Errors = result.Errors.ToList();
            return response;
        }

        response.Succeeded = result.Succeeded;
        return response;
    }
}