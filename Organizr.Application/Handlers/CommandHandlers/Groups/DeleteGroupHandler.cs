using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class DeleteGroupHandler : IRequestHandler<DeleteMemberGroupCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteMemberGroupCommand command, CancellationToken cancellationToken)
    {
        await _unitOfWork.GroupRepository.DeleteByIdAsync(command.Id);
        return Unit.Value;
    }
}