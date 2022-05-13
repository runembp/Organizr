using MediatR;
using Organizr.Application.Responses.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.Groups;

public class AddMemberToMemberGroupCommand : IRequest<AddMemberToMemberGroupResponse>
{
    public int GroupId { get; set; }
    public int MemberId { get; set; }
}