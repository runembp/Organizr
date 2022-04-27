using MediatR;
using Organizr.Application.Queries;
using Organizr.Core.Entities;
using Organizr.Core.Repositories.Base;

namespace Organizr.Application.Handlers.QueryHandlers
{
    public class GetAllOrganizrUserHandler : IRequestHandler<GetAllOrganizrUserQuery, List<OrganizrUser>>
    {
        private readonly IOrganizrUserRepository _memberRepo;

        public GetAllOrganizrUserHandler(IOrganizrUserRepository memberRepository)
        {
            _memberRepo = memberRepository;
        }
        public async Task<List<OrganizrUser>> Handle(GetAllOrganizrUserQuery request, CancellationToken cancellationToken)
        {
            return (List<OrganizrUser>)await _memberRepo.GetAllAsync();
        }
    }
}