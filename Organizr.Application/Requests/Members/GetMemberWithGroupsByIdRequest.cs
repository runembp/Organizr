using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Members;

public class GetMemberWithGroupsByIdRequest : IRequest<Member>
{
    public int MemberId { get; init; }
}