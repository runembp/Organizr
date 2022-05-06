using MediatR;
using Organizr.Application.Responses.Configurations;

namespace Organizr.Application.Commands;

public class UpdateConfigurationsOfTypeConfigCommand : IRequest<UpdateConfigurationsOfTypeConfigResponse>
{
    public string? OrganizationAddress { get; init; } = string.Empty;
    public string? OrganizationPhoneNumber { get; init; } = string.Empty;
    public string? OrganizationEmailAddress { get; init; } = string.Empty;
    public int? PredeterminedGroupToAssignNewMembersTo { get; init; } 
    public bool? ActivateCommentsOnNews { get; init; } 
    public bool? ActivateAdministratorMemberAbilityToCommentOnNews { get; init; } 
    public bool? ActivateBasicMemberAbilityToCommentOnNews { get; init; } 
    public bool? ActivateAbilityForAllMembersToCreateNews { get; init; } 
}