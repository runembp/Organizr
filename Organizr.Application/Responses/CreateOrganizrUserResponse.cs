namespace Organizr.Application.Responses
{
    public class CreateOrganizrUserResponse
    {
        public Guid OrganizrUserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Succeeded { get; set; }
    }
}
