using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Groups;

public class GetAllMembersRequest : IRequest<List<Member>>
{
}