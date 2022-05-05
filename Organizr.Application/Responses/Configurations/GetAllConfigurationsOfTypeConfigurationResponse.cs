using Organizr.Domain.Entities;

namespace Organizr.Application.Responses.Configurations;

public class GetAllConfigurationsOfTypeConfigurationResponse
{
    public List<Configuration> Configurations { get; init; } = new();
}