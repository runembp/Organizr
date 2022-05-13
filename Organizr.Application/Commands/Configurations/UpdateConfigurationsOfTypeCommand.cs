using MediatR;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

namespace Organizr.Application.Commands.Configurations;

public class UpdateConfigurationsOfTypeCommand : IRequest<List<Configuration>>
{
    public ConfigType ConfigType { get; init; }
    public List<Configuration> UpdatedConfigurations { get; init; } = new();
}