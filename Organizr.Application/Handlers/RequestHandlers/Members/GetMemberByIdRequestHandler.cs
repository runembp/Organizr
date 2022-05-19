using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Members;

public class GetMemberByIdRequestHandler : IRequestHandler<GetMemberByIdRequest, Member?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberByIdRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member?> Handle(GetMemberByIdRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.MemberRepository.GetByIdAsync(request.MemberId);
    }
}

