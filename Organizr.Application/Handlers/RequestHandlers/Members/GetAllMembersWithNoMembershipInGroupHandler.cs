using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Members;

public class GetAllMembersWithNoMembershipInGroupHandler : IRequestHandler<GetAllMembersWithNoMembershipInGroupRequest, List<Member>>
{
    private readonly IUnitOfWork _unitOfWork; 

    public GetAllMembersWithNoMembershipInGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Member>> Handle(GetAllMembersWithNoMembershipInGroupRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.MemberRepository.GetAllMembersWithNoMembershipInGroup(request.GroupId);
    }
}