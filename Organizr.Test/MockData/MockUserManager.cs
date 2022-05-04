using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Organizr.Core.Entities;

namespace Organizr.Test.MockData;

public abstract class MockUserManager : UserManager<Member>
{
    protected MockUserManager()
        : base(new Mock<IUserPasswordStore<Member>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<Member>>().Object,
            Array.Empty<IUserValidator<Member>>(),
            Array.Empty<IPasswordValidator<Member>>(),
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<Member>>>().Object)
    {
    }
}