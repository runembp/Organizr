using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Configurations;

namespace Organizr.Application.Handlers.CommandHandlers.Configurations;

public class UpdateConfigurationsOfTypeConfigHandler : IRequestHandler<UpdateConfigurationsOfTypeConfigCommand, UpdateConfigurationsOfTypeConfigResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateConfigurationsOfTypeConfigHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateConfigurationsOfTypeConfigResponse> Handle(UpdateConfigurationsOfTypeConfigCommand command, CancellationToken cancellationToken)
    {
        var response = new UpdateConfigurationsOfTypeConfigResponse { Succeeded = false };

        var result = await _unitOfWork.ConfigurationRepository.UpdateConfigurationOfTypeConfiguration(command);

        response.Succeeded = result;

        return response;
    }
}