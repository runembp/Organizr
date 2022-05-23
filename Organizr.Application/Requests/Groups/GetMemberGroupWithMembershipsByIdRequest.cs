using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Groups;

public class GetMemberGroupWithMembershipsByIdRequest : IRequest<MemberGroup?>
{
    public int GroupId { get; init; }    
}