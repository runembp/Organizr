using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests;

public class GetAllMembersRequest : IRequest<List<Member>>
{
}

