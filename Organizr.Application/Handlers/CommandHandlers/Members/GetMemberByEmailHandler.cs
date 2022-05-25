using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Members;

public class GetMemberByEmailHandler : IRequestHandler<GetMemberByEmailRequest, Member?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberByEmailHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member?> Handle(GetMemberByEmailRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.MemberRepository.GetMemberByEmail(request.Email);
    }
}