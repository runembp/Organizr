using MediatR;
using Organizr.Core.Entities;

namespace Organizr.Application.Queries
{
    public class GetAllOrganizrUserQuery : IRequest<List<OrganizrUser>>
    {
    }
}
