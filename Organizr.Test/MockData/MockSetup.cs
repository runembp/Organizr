using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using Organizr.Application.Common.IRepositories;
using Organizr.Application.Mapper;
using Organizr.Domain.Entities;

namespace Organizr.Test.MockData
{
    public static class MockSetup
    {
        public static IUnitOfWork GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();

            var memberRepository = MockMemberRepository.GetMemberRepository();
            var groupRepository = MockGroupRepository.GetMemberGroupRepository();
            var signInManager = new MockSignInManager();
            var userManager = MockUserManager<Member>();

            mockUow.Setup(repo => repo.MemberRepository).Returns(memberRepository.Object);
            mockUow.Setup(repo => repo.GroupRepository).Returns(groupRepository.Object);
            mockUow.Setup(manager => manager.SignInManager).Returns(signInManager);
            mockUow.Setup(manager => manager.UserManager).Returns(userManager.Object);

            return mockUow.Object;
        }

        public static IMapper GetMapper()
        {
            return new MapperConfiguration(c => { c.AddProfile<OrganizrMappingProfiler>(); }).CreateMapper();
        }

        private static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var userManager =
                new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            userManager.Object.UserValidators.Add(new UserValidator<TUser>());
            userManager.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            userManager.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            return userManager;
        }


    }
}