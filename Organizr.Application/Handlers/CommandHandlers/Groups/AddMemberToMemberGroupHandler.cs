using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class AddMemberToMemberGroupHandler : IRequestHandler<AddMemberToMemberGroupCommand, MemberGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddMemberToMemberGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MemberGroup?> Handle(AddMemberToMemberGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.GroupRepository.AddMemberToGroup(request.GroupId, request.MemberId);
        return group;
    }
}