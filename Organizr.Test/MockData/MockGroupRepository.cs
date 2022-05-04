using System.Collections.Generic;
using Moq;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Test.MockData;

public static class MockGroupRepository
{
    public static Mock<IMemberGroupRepository> GetMemberGroupRepository()
    {
        var memberGroups = new List<MemberGroup>
        {
            new ()
            {
                Id = 1,
                Name = "Test Gruppe 1",
                IsOpen = true
            },
            new ()
            {
                Id = 2,
                Name = "Test Gruppe 2",
                IsOpen = false
            },
            new ()
            {
                Id = 3,
                Name = "Test Gruppe 3",
                IsOpen = false
            },
        };

        var mockRepo = new Mock<IMemberGroupRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(memberGroups);

        mockRepo.Setup(r => r.Add(It.IsAny<MemberGroup>())).ReturnsAsync((MemberGroup userGroup) =>
        {
            memberGroups.Add(userGroup);
            return userGroup;
        });

        return mockRepo;
    }
}