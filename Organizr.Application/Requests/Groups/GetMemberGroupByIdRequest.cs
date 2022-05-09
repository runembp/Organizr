using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Groups;

public class GetMemberGroupByIdRequest : IRequest<MemberGroup>
{
    public int GroupId { get; init; }
}