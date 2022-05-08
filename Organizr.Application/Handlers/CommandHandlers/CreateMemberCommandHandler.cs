using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Organizr.Application.Commands;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses;
using Organizr.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, CreateMemberResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateMemberResponse> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Member>(command);

        var response = new CreateMemberResponse { Succeeded = false };

        if (user is null)
        {
            return response;
        }

        if (!new EmailAddressAttribute().IsValid(command.Email))
        {
            response.Errors.Add(new IdentityError { Description = "Email er ikke i et godkendt format" });
        }

        user.UserName = user.Email;

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        response.Succeeded = result.Succeeded;
        response.Errors.AddRange(result.Errors.ToList());

        return response;
    }
}