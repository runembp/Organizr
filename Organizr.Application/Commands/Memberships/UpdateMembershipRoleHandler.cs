using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Memberships;

namespace Organizr.Application.Commands.Memberships;

public class UpdateMembershipRoleHandler : IRequestHandler<UpdateMembershipRoleCommand, UpdateMembershipRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMembershipRoleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateMembershipRoleResponse> Handle(UpdateMembershipRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateMembershipRoleResponse();
        var result = await _unitOfWork.MembershipRepository.UpdateMembershipRole(request.MembershipId, request.RoleId);

        if (result is null)
        {
            response.Error = "Medlemsskabet findes ikke";
            return response;
        }

        response.Succeeded = true;
        return response;
    }
}