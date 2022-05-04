using MediatR;
using Organizr.Application.Responses.Configurations;

namespace Organizr.Application.Requests.Configurations;

public class GetAllConfigurationsOfTypeConfigurationRequest : IRequest<GetAllConfigurationsOfTypeConfigurationResponse>
{
}