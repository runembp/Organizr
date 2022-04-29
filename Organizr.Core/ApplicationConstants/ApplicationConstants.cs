namespace Organizr.Core.ApplicationConstants;

public static class ApplicationConstants
{
    // Endpoints
    public const string OrganizrApi = "https://localhost:7157/api";
    public const string LoginApiEndpoint = "api/auth/login";
    public const string LoginAsOrganisationAdministratorApiEndpoint = "/api/auth/login/organisation-administrator";
    
    // Roles
    public const string OrganizationAdministrator = "OrganizationAdministrator";
    public const string Administrator = "Administrator";
    public const string Basic = "Basic";
    
    // Hard-to-define variables
    public const string ApplicationJson = "application/json";
}