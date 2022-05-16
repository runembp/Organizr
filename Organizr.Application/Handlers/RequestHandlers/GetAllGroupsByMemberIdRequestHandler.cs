using AutoMapper;
using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers;

public class GetAllGroupsByMemberIdRequestHandler : IRequestHandler<GetAllGroupsByMemberIdRequest, Member>
{
    private readonly IUnitOfWork _unitOfWork;
   

    public GetAllGroupsByMemberIdRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
       
    }

    public async Task<Member> Handle(GetAllGroupsByMemberIdRequest request, CancellationToken cancellationToken)
    {
        var groups = await _unitOfWork.MemberRepository.GetAllGroupsByMemberId(request.MemberId);
        return groups;
       
    }

}