using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Roles;
using Organizr.Domain.ApplicationConstants;

namespace Organizr.Application.Handlers.RequestHandlers.Roles;

public class GetMemberRoleHandler : IRequestHandler<GetMemberRoleRequest, bool?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberRoleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<bool?> Handle(GetMemberRoleRequest request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.GetByIdAsync(request.MemberId);

        if (member.Id == 0)
        {
            return null;
        }

        return await _unitOfWork.UserManager.IsInRoleAsync(member, ApplicationConstants.OrganizationAdministrator);
    }
}