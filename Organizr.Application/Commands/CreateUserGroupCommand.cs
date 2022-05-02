using MediatR;
using Organizr.Application.Responses;

namespace Organizr.Application.Commands;

public class CreateUserGroupCommand : IRequest<CreateUserGroupResponse>
{
    public string GroupName { get; init; } = string.Empty;
    public bool GroupOpenForAll { get; init; }
}