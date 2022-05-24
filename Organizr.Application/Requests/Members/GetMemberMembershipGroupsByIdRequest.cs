using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Members;

public class GetMemberMembershipGroupsByIdRequest : IRequest<Member?>
{
    public int MemberId { get; set; }
}