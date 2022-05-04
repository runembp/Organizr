using MediatR;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.RequestHandlers;

public class GetAllMemberGroupsHandler : IRequestHandler<GetAllMemberGroupsRequest, GetAllMemberGroupsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMemberGroupsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetAllMemberGroupsResponse> Handle(GetAllMemberGroupsRequest request, CancellationToken cancellationToken)
    {
        var userGroups = await _unitOfWork.GroupRepository.GetAll();
        
        return new GetAllMemberGroupsResponse
        {
            MemberGroups = userGroups
        };
    }
}