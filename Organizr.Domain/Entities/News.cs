namespace Organizr.Domain.Entities;

public class News
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateOnly CreatedAtDate { get; set; }
    public TimeOnly CreatedAtTime { get; set; }
    public Boolean IsPublic { get; set; }
}

