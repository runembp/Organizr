using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Groups;

public class GetMemberGroupWithMembershipsByIdHandler : IRequestHandler<GetMemberGroupWithMembershipsByIdRequest, MemberGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberGroupWithMembershipsByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MemberGroup?> Handle(GetMemberGroupWithMembershipsByIdRequest request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.GroupRepository.GetMemberGroupWithMembershipsById(request.GroupId);
        return group;
    }
}