using AutoMapper;
using MediatR;
using Organizr.Application.Requests;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.RequestHandlers;

public class GetAllOrganizrUserHandler : IRequestHandler<GetAllOrganizrUserRequest, List<OrganizrUser>>
{
    private readonly IOrganizrUserRepository _memberRepo;
    private readonly IMapper _mapper;

    public GetAllOrganizrUserHandler(IOrganizrUserRepository memberRepository, IMapper mapper)
    {
        _memberRepo = memberRepository;
        _mapper = mapper;
    }
    public async Task<List<OrganizrUser>> Handle(GetAllOrganizrUserRequest request, CancellationToken cancellationToken)
    {
        var organizrUsers = await _memberRepo.GetAll();
        return _mapper.Map<List<OrganizrUser>>(organizrUsers);
    }
}
