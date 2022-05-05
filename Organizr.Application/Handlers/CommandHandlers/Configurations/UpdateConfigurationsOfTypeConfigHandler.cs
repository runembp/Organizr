using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Common.IRepositories;
using Organizr.Application.Responses.Configurations;
using Organizr.Domain.ApplicationConstants;

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
        var response = new UpdateConfigurationsOfTypeConfigResponse {Succeeded = false};

        await _unitOfWork.ConfigurationRepository.UpdateConfigurationBasedOnIdAndStringValue(ConfigurationIds.OrganizationAddress, command.OrganizationAddress.StringValue);
        await _unitOfWork.ConfigurationRepository.UpdateConfigurationBasedOnIdAndStringValue(ConfigurationIds.OrganizationPhoneNumber, command.OrganizationPhoneNumber.StringValue);
        await _unitOfWork.ConfigurationRepository.UpdateConfigurationBasedOnIdAndStringValue(ConfigurationIds.OrganizationEmailAddress, command.OrganizationEmailAddress.StringValue);
        await _unitOfWork.ConfigurationRepository.UpdateConfigurationBasedOnIdAndIdValue(ConfigurationIds.PredeterminedGroupToAssignNewMembersTo, command.PredeterminedGroupToAssignNewMembersTo.IdValue);
        await _unitOfWork.ConfigurationRepository.UpdateConfigurationBasedOnIdAndBoolValue(ConfigurationIds.ActivateCommentsOnNews, command.ActivateCommentsOnNews.BoolValue);
        await _unitOfWork.ConfigurationRepository.UpdateConfigurationBasedOnIdAndBoolValue(ConfigurationIds.ActivateAdministratorMemberAbilityToCommentOnNews, command.ActivateAdministratorMemberAbilityToCommentOnNews.BoolValue);
        await _unitOfWork.ConfigurationRepository.UpdateConfigurationBasedOnIdAndBoolValue(ConfigurationIds.ActivateBasicMemberAbilityToCommentOnNews, command.ActivateBasicMemberAbilityToCommentOnNews.BoolValue);
        await _unitOfWork.ConfigurationRepository.UpdateConfigurationBasedOnIdAndBoolValue(ConfigurationIds.ActivateCommentsOnNews, command.ActivateCommentsOnNews.BoolValue);
        
        return response;
    }
}