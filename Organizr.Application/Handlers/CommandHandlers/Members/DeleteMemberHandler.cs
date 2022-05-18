using MediatR;
using Organizr.Application.Commands.Members;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Member;

namespace Organizr.Application.Handlers.CommandHandlers.Members;

public class DeleteMemberHandler : IRequestHandler<DeleteMemberCommand, DeleteMemberResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMemberHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteMemberResponse> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var response = new DeleteMemberResponse();
        var result = await _unitOfWork.MemberRepository.DeleteByIdAsync(request.MemberId);

        if (result is null)
        {
            response.Error = "Medlem kunne ikke slettes";
            return response;
        }

        response.Succeeded = true;
        return response;
    }
}