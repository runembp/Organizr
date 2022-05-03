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
        var user = new OrganizrUser
        {
            UserName = command.Email,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Address = command.Address,
        };

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        var roleResult = new IdentityResult();

        if (result.Succeeded)
        {
            roleResult = await _unitOfWork.UserManager.AddToRoleAsync(user, ApplicationConstants.OrganizationAdministrator);
        }

        return new CreateUserResponse
        {
            Succeeded = roleResult.Succeeded,
            Errors = roleResult.Errors.ToList()
        };
    }
}