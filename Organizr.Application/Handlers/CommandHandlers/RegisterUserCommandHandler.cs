using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.CommandHandlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = new RegisterUserResponse();

        if(!new EmailAddressAttribute().IsValid(request.Email))
        {
            response.Errors.Add(new IdentityError { Description = "Email er ikke i et godkendt format" });
            return response;
        }

        var user = new OrganizrUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.LastName,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            ConfigRefreshPrivilege = request.ConfigRefreshPrivilege
        };

        var result = await _unitOfWork.UserManager.CreateAsync(user, request.Password);

        return new RegisterUserResponse
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.ToList()
        };
    }
}