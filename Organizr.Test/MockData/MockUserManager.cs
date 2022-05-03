using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Organizr.Core.Entities;

namespace Organizr.Test.MockData;

public abstract class MockUserManager : UserManager<OrganizrUser>
{
    protected MockUserManager()
        : base(new Mock<IUserPasswordStore<OrganizrUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<OrganizrUser>>().Object,
            Array.Empty<IUserValidator<OrganizrUser>>(),
            Array.Empty<IPasswordValidator<OrganizrUser>>(),
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<OrganizrUser>>>().Object)
    {
    }
}