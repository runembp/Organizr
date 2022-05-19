using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Groups;

public class GetAllMemberGroupsWithNoMembershipOfMemberHandler : IRequestHandler<GetAllMemberGroupsWithNoMembershipOfMemberRequest, List<MemberGroup>?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMemberGroupsWithNoMembershipOfMemberHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<MemberGroup>?> Handle(GetAllMemberGroupsWithNoMembershipOfMemberRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.GroupRepository.GetOpenMembergroupsWhereMemberHasNoMembership(request.MemberId);
    }
}