using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Groups;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class DeleteGroupHandler : IRequestHandler<DeleteMemberGroupCommand, DeleteMemberGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteMemberGroupResponse> Handle(DeleteMemberGroupCommand command, CancellationToken cancellationToken)
    {
        var response = new DeleteMemberGroupResponse();
        var result = await _unitOfWork.GroupRepository.DeleteByIdAsync(command.Id);

        if (result is null)
        {
            return response;
        }

        response.Succeeded = true;
        return response;
    }
}