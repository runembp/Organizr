using MediatR;
using Organizr.Application.Commands.Configurations;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Configurations;

namespace Organizr.Application.Handlers.CommandHandlers.Configurations;

public class UpdateConfigurationsOfTypeCssSetupHandler : IRequestHandler<UpdateConfigurationsOfTypeCssSetupCommand, UpdateConfigurationsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateConfigurationsOfTypeCssSetupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateConfigurationsResponse> Handle(UpdateConfigurationsOfTypeCssSetupCommand command, CancellationToken cancellationToken)
    {
        var response = new UpdateConfigurationsResponse { Succeeded = false };
        var result = await _unitOfWork.ConfigurationRepository.UpdateConfigurationOfTypeCssSetup(command);

        response.Succeeded = result > 0;
        return response;
    }
}