using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.Groups;

public class CreateMemberGroupCommand : IRequest<MemberGroup?>
{
    public string Name { get; init; } = string.Empty;
    public bool IsOpen { get; init; }
}