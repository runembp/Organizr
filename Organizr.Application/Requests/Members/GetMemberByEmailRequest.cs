using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Members;

public class GetMemberByEmailRequest : IRequest<Member?>
{
    public string Email { get; init; } = string.Empty;
}