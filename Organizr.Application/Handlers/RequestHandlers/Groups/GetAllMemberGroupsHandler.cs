using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Groups;

public class GetAllMemberGroupsHandler : IRequestHandler<GetAllMemberGroupsRequest, List<MemberGroup>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMemberGroupsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<MemberGroup>> Handle(GetAllMemberGroupsRequest request, CancellationToken cancellationToken)
    {
        var memberGroups = await _unitOfWork.GroupRepository.GetAll();
        return (List<MemberGroup>)memberGroups;
    }
}