using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.ApplicationConstants;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.CommandHandlers;

public class RegisterOrganizationAdministratorCommandHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterOrganizationAdministratorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var user = new OrganizrUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
        };

        var result = await _unitOfWork.UserManager.CreateAsync(user, request.Password);

        var roleResult = new IdentityResult();

        if (result.Succeeded)
        {
            roleResult = await _unitOfWork.UserManager.AddToRoleAsync(user, ApplicationConstants.OrganizationAdministrator);
        }

        return new RegisterUserResponse
        {
            Succeeded = roleResult.Succeeded,
            Errors = roleResult.Errors.ToList()
        };
    }
}