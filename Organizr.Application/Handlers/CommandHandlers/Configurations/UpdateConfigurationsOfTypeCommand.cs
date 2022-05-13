using AutoMapper;
using MediatR;
using Organizr.Application.Commands.Configurations;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

namespace Organizr.Application.Handlers.CommandHandlers.Configurations;

public class UpdateConfigurationsOfTypeHandler : IRequestHandler<UpdateConfigurationsOfTypeCommand, List<Configuration>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateConfigurationsOfTypeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<Configuration>> Handle(UpdateConfigurationsOfTypeCommand command, CancellationToken cancellationToken)
    {
        var configurations = _mapper.Map<List<Configuration>>(command.UpdatedConfigurations);
        
        switch (command.ConfigType)
        {
            case ConfigType.Configuration:
                await _unitOfWork.ConfigurationRepository.UpdateConfigurationOfTypeConfiguration(command.UpdatedConfigurations);
                break;
            case ConfigType.PageSetup:
                await _unitOfWork.ConfigurationRepository.UpdateConfigurationOfTypePageSetup(command.UpdatedConfigurations);
                break;
            case ConfigType.CssSetup:
                await _unitOfWork.ConfigurationRepository.UpdateConfigurationOfTypeCssSetup(command.UpdatedConfigurations);
                break;
        }

        return configurations;
    }
}