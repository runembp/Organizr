using System.Collections.Generic;
using Moq;
using Organizr.Core.Entities;
using Organizr.Core.Enums;
using Organizr.Core.Repositories;

namespace Organizr.Test.MockData
{
    public static class MockOrganizrUserRepository
    {
        public static Mock<IUserRepository> GetOrganizrUserRepository()
        {
            var organizrUsers = new List<OrganizrUser>
            {
                 new OrganizrUser
                {
                    FirstName = "Fornavn",
                    LastName = "Efternavn",
                    Email = "emailtest",
                    PhoneNumber = "12345678",
                    Address = "Testvej 12 9430 Vadum",
                    Gender = Gender.Male,
                },
                 new OrganizrUser
                {
                    FirstName = "FornavnTest",
                    LastName = "EfternavnTest",
                    Email = "emailtest01",
                    PhoneNumber = "12345678",
                    Address = "Testvej 78 2450 København SV",
                    Gender = Gender.Female
                }
            };

            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(organizrUsers);

            mockRepo.Setup(r => r.Add(It.IsAny<OrganizrUser>())).ReturnsAsync((OrganizrUser organizrUser) =>
            {
                organizrUsers.Add(organizrUser);
                return organizrUser;
            });

            return mockRepo;
        }
    }
}
