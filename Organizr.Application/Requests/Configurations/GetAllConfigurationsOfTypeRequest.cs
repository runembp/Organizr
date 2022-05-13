using MediatR;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

namespace Organizr.Application.Requests.Configurations;

public class GetAllConfigurationsOfTypeRequest : IRequest<List<Configuration>>
{
    public ConfigType ConfigType { get; init; }
}