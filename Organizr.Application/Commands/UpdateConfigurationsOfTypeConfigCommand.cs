using MediatR;
using Organizr.Application.Responses.Configurations;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands;

public class UpdateConfigurationsOfTypeConfigCommand : IRequest<UpdateConfigurationsOfTypeConfigResponse>
{
    public Configuration OrganizationAddress { get; set; } = new ();
    public Configuration OrganizationPhoneNumber { get; set; } = new ();
    public Configuration OrganizationEmailAddress { get; set; } = new ();
    public Configuration PredeterminedGroupToAssignNewMembersTo { get; set; } = new ();
    public Configuration ActivateCommentsOnNews { get; set; } = new ();
    public Configuration ActivateAdministratorMemberAbilityToCommentOnNews { get; set; } = new ();
    public Configuration ActivateBasicMemberAbilityToCommentOnNews { get; set; } = new ();
    public Configuration ActivateAbilityForAllMembersToCreateNews { get; set; } = new ();
}