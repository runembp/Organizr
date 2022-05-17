using MediatR;
using Organizr.Application.Responses.Member;

namespace Organizr.Application.Commands.Members;

public class DeleteMemberCommand : IRequest<DeleteMemberResponse>
{
    public int MemberId { get; set; }
}