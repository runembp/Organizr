using MediatR;
using Organizr.Application.Requests.Configurations;
using Organizr.Application.Responses.Configurations;
using Organizr.Core.IRepositories;

namespace Organizr.Application.Handlers.RequestHandlers.Configurations;

public class GetAllConfigurationsOfTypeConfigurationHandler : IRequestHandler<GetAllConfigurationsOfTypeConfigurationRequest, GetAllConfigurationsOfTypeConfigurationResponse>
{
    private readonly IConfigurationRepository _configurationRepository;

    public GetAllConfigurationsOfTypeConfigurationHandler(IConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
    }

    public async Task<GetAllConfigurationsOfTypeConfigurationResponse> Handle(GetAllConfigurationsOfTypeConfigurationRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAllConfigurationsOfTypeConfigurationResponse
        {
            Configurations = await _configurationRepository.GetConfigurationsOfConfigTypeConfig()
        };
        
        return response;
    }
}