using MediatR;

namespace Organizr.Application.Commands.Groups;

public class DeleteMemberGroupCommand : IRequest
{
    public int Id { get; set; }
}