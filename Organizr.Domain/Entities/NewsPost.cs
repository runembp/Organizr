namespace Organizr.Domain.Entities;

public class NewsPost
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Boolean IsPublic { get; set; }
    public Member? Member { get; set; }
}