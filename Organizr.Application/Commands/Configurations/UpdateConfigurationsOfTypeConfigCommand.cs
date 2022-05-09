using MediatR;
using Organizr.Application.Responses.Configurations;

namespace Organizr.Application.Commands.Configurations;

public class UpdateConfigurationsOfTypeConfigCommand : IRequest<UpdateConfigurationsResponse>
{
    public string? OrganizationAddress { get; init; }
    public string? OrganizationPhoneNumber { get; init; }
    public string? OrganizationEmailAddress { get; init; }
    public int? PredeterminedGroupToAssignNewMembersTo { get; init; } 
    public bool? ActivateCommentsOnNews { get; init; } 
    public bool? ActivateAdministratorMemberAbilityToCommentOnNews { get; init; } 
    public bool? ActivateBasicMemberAbilityToCommentOnNews { get; init; } 
    public bool? ActivateAbilityForAllMembersToCreateNews { get; init; } 
}