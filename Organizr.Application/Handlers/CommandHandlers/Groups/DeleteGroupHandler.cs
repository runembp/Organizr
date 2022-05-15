using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class DeleteGroupHandler : IRequestHandler<DeleteMemberGroupCommand, MemberGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MemberGroup?> Handle(DeleteMemberGroupCommand command, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.GroupRepository.DeleteByIdAsync(command.Id);
        return result;
    }
}