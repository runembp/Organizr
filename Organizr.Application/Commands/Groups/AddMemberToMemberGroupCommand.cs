using MediatR;
using Organizr.Application.Responses.Groups;

namespace Organizr.Application.Commands.Groups;

public class AddMemberToMemberGroupCommand : IRequest<AddMemberToMemberGroupResponse>
{
    public int GroupId { get; init; }
    public int MemberId { get; init; }
}