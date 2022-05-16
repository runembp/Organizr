using MediatR;
using Organizr.Application.Responses.Groups;

namespace Organizr.Application.Commands.Groups;

public class UpdateMemberGroupCommand : IRequest<UpdateMemberGroupResponse>
{
    public int Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public bool IsOpen { get; init; }
}