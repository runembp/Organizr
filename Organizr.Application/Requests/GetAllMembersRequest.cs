using MediatR;
using Organizr.Core.Entities;

namespace Organizr.Application.Requests;

public class GetAllMembersRequest : IRequest<List<Member>>
{
}

