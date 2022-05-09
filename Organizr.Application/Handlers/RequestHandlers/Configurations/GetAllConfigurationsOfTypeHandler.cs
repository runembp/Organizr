using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Configurations;
using Organizr.Application.Responses.Configurations;


namespace Organizr.Application.Handlers.RequestHandlers.Configurations;

public class GetAllConfigurationsOfTypeHandler : IRequestHandler<GetAllConfigurationsOfTypeRequest, GetAllConfigurationsOfTypeResponse>
{
    private readonly IConfigurationRepository _configurationRepository;

    public GetAllConfigurationsOfTypeHandler(IConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
    }

    public async Task<GetAllConfigurationsOfTypeResponse> Handle(GetAllConfigurationsOfTypeRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAllConfigurationsOfTypeResponse
        {
            Configurations = await _configurationRepository.GetConfigurationsOfConfigType(request.ConfigType)
        };

        return response;
    }
}