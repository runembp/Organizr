using Organizr.Domain.Entities;

namespace Organizr.Application.Responses.Configurations;

public class GetAllConfigurationsOfTypeResponse
{
    public List<Configuration> Configurations { get; init; } = new();
}