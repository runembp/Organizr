using MediatR;
using Organizr.Application.Responses;

namespace Organizr.Application.Commands;

public class CreateUserGroupCommand : IRequest<CreateUserGroupResponse>
{
    public string Name { get; init; } = string.Empty;
    public bool Open { get; init; }
}