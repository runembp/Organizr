using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Groups;

public class GetMemberGroupWithMembersByIdHandler : IRequestHandler<GetMemberGroupWithMembersByIdRequest, MemberGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberGroupWithMembersByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MemberGroup?> Handle(GetMemberGroupWithMembersByIdRequest request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.GroupRepository.GetMemberGroupWithMembers(request.GroupId);
        return group;
    }
}