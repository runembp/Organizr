using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.Groups;

public class AddMemberToMemberGroupCommand : IRequest<MemberGroup>
{
    public int GroupId { get; set; }
    public int MemberId { get; set; }
}