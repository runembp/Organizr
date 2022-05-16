using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests;

public class GetAllGroupsByMemberIdRequest : IRequest<Member>
{
    public int MemberId { get; init; }
}