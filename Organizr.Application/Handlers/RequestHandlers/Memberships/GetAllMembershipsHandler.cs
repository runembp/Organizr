using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Memberships;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Memberships;

public class GetAllMembershipsHandler : IRequestHandler<GetAllMembershipsRequest, List<Membership>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMembershipsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Membership>> Handle(GetAllMembershipsRequest request, CancellationToken cancellationToken)
    {
        var result = (List<Membership>) await _unitOfWork.MembershipRepository.GetAll();
        return result;
    }
}