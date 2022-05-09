using Organizr.Domain.Enums;

namespace Organizr.Domain.Entities;

public class Configuration
{
    public int Id { get; set; }
    public ConfigType ConfigType { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? StringValue { get; set; }
    public bool? BoolValue { get; set; }
    public int? IdValue { get; set; }
}