using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.Groups;

public class RemoveMemberFromGroupCommand : IRequest<Member>
{
    public int GroupId { get; set; }
    public int MemberId { get; set; }
}