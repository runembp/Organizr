using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.Groups;

public class DeleteMemberGroupCommand : IRequest<MemberGroup?>
{
    public int Id { get; init; }
}