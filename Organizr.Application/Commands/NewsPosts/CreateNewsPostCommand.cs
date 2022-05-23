using MediatR;
using Organizr.Application.Responses.NewsPost;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.NewsPosts;

public class CreateNewsPostCommand : IRequest<CreateNewsPostResponse>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsPublic { get; set; }
    public int MemberId { get; set; }
    public int MemberGroupId { get; set; }
}