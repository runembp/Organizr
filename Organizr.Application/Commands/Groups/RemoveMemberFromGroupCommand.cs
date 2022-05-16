using MediatR;

namespace Organizr.Application.Commands.Groups;

public class RemoveMemberFromGroupCommand : IRequest<RemoveMemberFromMemberGroupResponse>
{
    public int GroupId { get; init; }
    public int MemberId { get; init; }
}