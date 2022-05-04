using System.Collections.Generic;
using Moq;
using Organizr.Core.Entities;
using Organizr.Core.Enums;
using Organizr.Core.Repositories;

namespace Organizr.Test.MockData
{
    public static class MockMemberRepository
    {
        public static Mock<IMemberRepository> GetMemberRepository()
        {
            var members = new List<Member>
            {
                 new ()
                {
                    FirstName = "Fornavn",
                    LastName = "Efternavn",
                    Email = "emailtest",
                    PhoneNumber = "12345678",
                    Address = "Testvej 12 9430 Vadum",
                    Gender = Gender.Male,
                },
                 new ()
                {
                    FirstName = "FornavnTest",
                    LastName = "EfternavnTest",
                    Email = "emailtest01",
                    PhoneNumber = "12345678",
                    Address = "Testvej 78 2450 København SV",
                    Gender = Gender.Female
                }
            };

            var mockRepo = new Mock<IMemberRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(members);

            mockRepo.Setup(r => r.Add(It.IsAny<Member>())).ReturnsAsync((Member member) =>
            {
                members.Add(member);
                return member;
            });

            return mockRepo;
        }
    }
}