using Organizr.Core.Enums;

namespace Organizr.Core.Entities;

public class Configuration
{
    public int Id { get; set; }
    public ConfigType ConfigType { get; set; }
    public string? Description { get; set; } = null;
    public string? StringValue { get; set; } = null;
    public bool? BoolValue { get; set; } = null;
    public int? IdValues { get; set; } = null; 
}