using AutoMapper;
using MediatR;
using Organizr.Application.Requests;
using Organizr.Core.Entities;
using Organizr.Core.IRepositories;

namespace Organizr.Application.Handlers.RequestHandlers;

public class GetAllMembersHandler : IRequestHandler<GetAllMembersRequest, List<Member>>
{
    private readonly IMemberRepository _memberRepo;
    private readonly IMapper _mapper;

    public GetAllMembersHandler(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepo = memberRepository;
        _mapper = mapper;
    }
    public async Task<List<Member>> Handle(GetAllMembersRequest request, CancellationToken cancellationToken)
    {
        var members = await _memberRepo.GetAll();
        return _mapper.Map<List<Member>>(members);
    }
}
