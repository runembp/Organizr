using AutoMapper;
using MediatR;
using Organizr.Application.Queries;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.QueryHandlers;

public class GetAllOrganizrUserHandler : IRequestHandler<GetAllOrganizrUserQuery, List<OrganizrUser>>
{
    private readonly IOrganizrUserRepository _memberRepo;
    private readonly IMapper _mapper;

    public GetAllOrganizrUserHandler(IOrganizrUserRepository memberRepository, IMapper mapper)
    {
        _memberRepo = memberRepository;
        _mapper = mapper;
    }
    public async Task<List<OrganizrUser>> Handle(GetAllOrganizrUserQuery request, CancellationToken cancellationToken)
    {
        var organizrUsers = await _memberRepo.GetAll();
        return _mapper.Map<List<OrganizrUser>>(organizrUsers);
    }
}
