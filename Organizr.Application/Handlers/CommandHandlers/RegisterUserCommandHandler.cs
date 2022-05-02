using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.CommandHandlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var response = new RegisterUserResponse();

        if(!new EmailAddressAttribute().IsValid(command.Email))
        {
            response.Errors.Add(new IdentityError { Description = "Email er ikke i et godkendt format" });
            return response;
        }

        var user = new OrganizrUser
        {
            UserName = command.Email,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Address = command.LastName,
            Gender = command.Gender,
            PhoneNumber = command.PhoneNumber,
            ConfigRefreshPrivilege = command.ConfigRefreshPrivilege
        };

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        return new RegisterUserResponse
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.ToList()
        };
    }
}