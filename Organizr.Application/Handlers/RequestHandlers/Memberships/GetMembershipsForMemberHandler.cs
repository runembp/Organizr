using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Memberships;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Memberships;

public class GetMembershipsForMemberHandler : IRequestHandler<GetMembershipsForMemberRequest, List<Membership>?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMembershipsForMemberHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Membership>?> Handle(GetMembershipsForMemberRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.MembershipRepository.GetMembershipsForMember(request.MemberId);
    }
}