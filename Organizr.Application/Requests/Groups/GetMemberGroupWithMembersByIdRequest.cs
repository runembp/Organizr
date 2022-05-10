using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Groups;

public class GetMemberGroupWithMembersByIdRequest : IRequest<MemberGroup?>
{
    public int GroupId { get; init; }    
}