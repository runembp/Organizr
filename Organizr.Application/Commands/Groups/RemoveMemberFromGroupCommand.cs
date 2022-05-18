using MediatR;
using Organizr.Application.Responses.Groups;

namespace Organizr.Application.Commands.Groups;

public class RemoveMemberFromGroupCommand : IRequest<RemoveMemberFromGroupResponse>
{
    public int GroupId { get; init; }
    public int MemberId { get; init; }
}