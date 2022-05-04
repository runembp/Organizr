using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Organizr.Application.Commands;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using System.ComponentModel.DataAnnotations;

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
        var user = _mapper.Map<OrganizrUser>(command);
        
        var response = new CreateUserResponse {Succeeded = false};
        
        if (user is null)
        {
            return response;
        }

        if (!new EmailAddressAttribute().IsValid(command.Email))
        {
            response.Errors.Add(new IdentityError {Description = "Email er ikke i et godkendt format"});
        }
        
        user.UserName = user.Email;

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        response.Succeeded = result.Succeeded;
        response.Errors.AddRange(result.Errors.ToList());

        return response;
    }
}