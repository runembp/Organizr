using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Organizr.Core.Entities;

namespace Organizr.Test.MockData;

public class MockSignInManager : SignInManager<OrganizrUser>
{
    public MockSignInManager()
        : base(new Mock<MockUserManager>().Object,
            new HttpContextAccessor(),
            new Mock<IUserClaimsPrincipalFactory<OrganizrUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<OrganizrUser>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object, null)
    {
    }
}