using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Memberships;

public class GetAllMembershipsRequest : IRequest<List<Membership>>
{
    
}