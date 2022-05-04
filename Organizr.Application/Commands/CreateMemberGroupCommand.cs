using MediatR;
using Organizr.Application.Responses;

namespace Organizr.Application.Commands;

public class CreateMemberGroupCommand : IRequest<CreateMemberGroupResponse>
{
    public string Name { get; init; } = string.Empty;
    public bool IsOpen { get; init; }
}