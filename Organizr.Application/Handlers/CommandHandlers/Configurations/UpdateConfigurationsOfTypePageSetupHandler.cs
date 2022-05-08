using MediatR;
using Organizr.Application.Commands.Configurations;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Configurations;

namespace Organizr.Application.Handlers.CommandHandlers.Configurations;

public class UpdateConfigurationsOfTypePageSetupHandler : IRequestHandler<UpdateConfigurationsOfTypePageSetupCommand, UpdateConfigurationsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateConfigurationsOfTypePageSetupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateConfigurationsResponse> Handle(UpdateConfigurationsOfTypePageSetupCommand command, CancellationToken cancellationToken)
    {
        var response = new UpdateConfigurationsResponse {Succeeded = false};

        var result = await _unitOfWork.ConfigurationRepository.UpdateConfigurationOfTypePageSetup(command);

        response.Succeeded = result > 0;
        
        return response;
    }
}