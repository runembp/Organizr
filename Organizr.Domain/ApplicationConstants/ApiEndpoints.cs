namespace Organizr.Domain.ApplicationConstants;

public static class ApiEndpoints
{
    public const string Login = "api/auth/signin";
    
    public const string GetAllMembers = "api/organizr-member";
    public const string PostNewMember = "api/members";

    public const string GetAllGroups = "api/groups";
    public const string PostNewGroup = "api/groups";
    public const string GetMemberGroupWithMembersById = "ToBeDecided";
    public const string UpdateMemberGroup = "ToBeDecided";
    public const string AddMemberToGroup = "ToBeDecided";
    public const string RemoveMemberFromGroup = "ToBeDecided";
    public const string DeleteGroupById = "ToBeDecided";
    
    public const string GetAllConfigurations = "api/configurations";
    public const string GetAllConfigurationsOfType = "ToBeDecided";
    public const string UpdateConfigurationsOfTypeConfiguration = "ToBeDecided";
    public const string UpdateConfigurationsOfTypeCssSetup = "ToBeDecided";
    public const string UpdateConfigurationsOfTypePageSetup = "ToBeDecided";

    
}