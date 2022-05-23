namespace Organizr.Application.Responses.NewsPost;

public class CreateNewsPostResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
    public Domain.Entities.NewsPost CreatedNewsPost { get; set; } = new();
}