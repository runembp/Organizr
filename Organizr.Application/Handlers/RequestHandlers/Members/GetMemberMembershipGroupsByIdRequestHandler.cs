using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Members;

public class GetMemberMembershipGroupsByIdRequestHandler : IRequestHandler<GetMemberMembershipGroupsByIdRequest, Member?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberMembershipGroupsByIdRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member?> Handle(GetMemberMembershipGroupsByIdRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.MemberRepository.GetMemberMembershipGroupsById(request.MemberId);
    }
}

