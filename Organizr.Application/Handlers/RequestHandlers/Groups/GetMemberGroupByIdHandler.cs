using AutoMapper;
using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Groups;

public class GetMemberGroupByIdHandler : IRequestHandler<GetMemberGroupByIdRequest, MemberGroup>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMemberGroupByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MemberGroup> Handle(GetMemberGroupByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.GroupRepository.GetByIdAsync(request.GroupId);
        return _mapper.Map<MemberGroup>(response);
    }
}