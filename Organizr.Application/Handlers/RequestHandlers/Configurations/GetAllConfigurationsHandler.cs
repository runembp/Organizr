using AutoMapper;
using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Configurations;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.Configurations;

public class GetAllConfigurationsRequestHandler : IRequestHandler<GetAllConfigurationsRequest, List<Configuration>>
{
    private readonly IConfigurationRepository _configRepo;
    private readonly IMapper _mapper;

    public GetAllConfigurationsRequestHandler(IConfigurationRepository configurationRepository, IMapper mapper)
    {
        _configRepo = configurationRepository;
        _mapper = mapper;
    }
    public async Task<List<Configuration>> Handle(GetAllConfigurationsRequest request, CancellationToken cancellationToken)
    {
        var configurations = await _configRepo.GetAll();
        return _mapper.Map<List<Configuration>>(configurations);
    }
}

