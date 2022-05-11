using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.Groups;

public class UpdateMemberGroupCommand : IRequest<MemberGroup>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool IsOpen { get; init; }
}