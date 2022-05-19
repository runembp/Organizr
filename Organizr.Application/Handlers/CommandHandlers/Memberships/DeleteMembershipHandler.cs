using MediatR;
using Organizr.Application.Commands.Memberships;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Memberships;

namespace Organizr.Application.Handlers.CommandHandlers.Memberships;

public class DeleteMembershipHandler : IRequestHandler<DeleteMembershipCommand, DeleteMembershipResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMembershipHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteMembershipResponse> Handle(DeleteMembershipCommand request, CancellationToken cancellationToken)
    {
        var response = new DeleteMembershipResponse();
        
        var result = await _unitOfWork.MembershipRepository.DeleteByIdAsync(request.MembershipId);

        if (result is null)
        {
            response.Error = "Medlemsskabet kunne ikke findes";
            return response;
        }

        response.Succeeded = true;
        return response;
    }
}