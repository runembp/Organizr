using MediatR;
using Organizr.Application.Responses.Groups;

namespace Organizr.Application.Commands.Groups;

public class DeleteMemberGroupCommand : IRequest<DeleteMemberGroupResponse>
{
    public int Id { get; init; }
}