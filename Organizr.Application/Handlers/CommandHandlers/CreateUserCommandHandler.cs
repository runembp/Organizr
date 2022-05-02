using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Organizr.Application.Commands;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var response = new CreateUserResponse();

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

        return new CreateUserResponse
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.ToList()
        };
    }
}