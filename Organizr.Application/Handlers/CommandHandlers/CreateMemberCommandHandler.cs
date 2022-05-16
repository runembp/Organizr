using AutoMapper;
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Organizr.Application.Responses.Member;

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
        var response = new CreateMemberResponse();
        var user = _mapper.Map<Member>(command);

        if (user is null)
        {
            response.Error = "Medlem er ikke i et korrekt format";
            return response;
        }

        if (!new EmailAddressAttribute().IsValid(command.Email))
        {
            response.Error = "Email er ikke i et korrekt format";
            return response;
        }

        user.UserName = user.Email;

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            response.Error = "Medlem kunne ikke oprettes";
        }

        var createdMember = await _unitOfWork.UserManager.FindByEmailAsync(command.Email);

        response.Succeeded = true;
        response.CreatedMember = createdMember;
        return response;
    }
}