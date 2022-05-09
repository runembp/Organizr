using MediatR;
using Organizr.Application.Responses.Configurations;
using Organizr.Domain.Enums;

namespace Organizr.Application.Requests.Configurations;

public class GetAllConfigurationsOfTypeRequest : IRequest<GetAllConfigurationsOfTypeResponse>
{
    public ConfigType ConfigType { get; set; }
}