using System.Collections.Generic;
using Moq;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Test.MockData;

public static class MockGroupRepository
{
    public static Mock<IUserGroupRepository> GetUserGroupRepository()
    {
        var userGroups = new List<UserGroup>
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

        var mockRepo = new Mock<IUserGroupRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(userGroups);

        mockRepo.Setup(r => r.Add(It.IsAny<UserGroup>())).ReturnsAsync((UserGroup userGroup) =>
        {
            userGroups.Add(userGroup);
            return userGroup;
        });

        return mockRepo;
    }
}