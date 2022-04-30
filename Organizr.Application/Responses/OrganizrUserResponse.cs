﻿using Organizr.Core.Enums;

namespace Organizr.Application.Responses
{
    public class OrganizrUserResponse
    {
        public Guid OrganizrUserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Undefined;
        public bool Succeeded { get; set; }
    }
}
