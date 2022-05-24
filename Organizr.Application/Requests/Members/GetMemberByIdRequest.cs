using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Members;

public class GetMemberByIdRequest : IRequest<Member?>
{
    public int MemberId { get; init; }
}

