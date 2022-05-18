using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Members;

public class GetMemberWithGroupsByIdHandler : IRequestHandler<GetMemberWithGroupsByIdRequest, Member?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberWithGroupsByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member?> Handle(GetMemberWithGroupsByIdRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.MemberRepository.GetMemberWithGroupsById(request.MemberId);
    }
}