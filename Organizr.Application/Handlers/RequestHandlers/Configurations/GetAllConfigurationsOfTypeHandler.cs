using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Configurations;
using Organizr.Domain.Entities;


namespace Organizr.Application.Handlers.RequestHandlers.Configurations;

public class GetAllConfigurationsOfTypeHandler : IRequestHandler<GetAllConfigurationsOfTypeRequest, List<Configuration>>
{
    private readonly IConfigurationRepository _configurationRepository;

    public GetAllConfigurationsOfTypeHandler(IConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
    }

    public async Task<List<Configuration>> Handle(GetAllConfigurationsOfTypeRequest request, CancellationToken cancellationToken)
    {
        return await _configurationRepository.GetConfigurationsOfConfigType(request.ConfigType);
    }
}