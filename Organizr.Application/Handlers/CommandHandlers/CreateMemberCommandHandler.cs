using AutoMapper;
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Member?> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Member>(command);

        if (user is null)
        {
            return null;
        }

        if (!new EmailAddressAttribute().IsValid(command.Email))
        {
            return null;
        }

        user.UserName = user.Email;

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            return null;
        }

        var createdMember = await _unitOfWork.UserManager.FindByEmailAsync(command.Email);

        return createdMember;
    }
}