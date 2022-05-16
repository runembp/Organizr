using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.Groups;

public class RemoveMemberFromGroupCommand : IRequest<MemberGroup?>
{
    public int GroupId { get; init; }
    public int MemberId { get; init; }
}