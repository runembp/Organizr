using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Core.Entities;
using Organizr.Test.MockData;
using Shouldly;
using Xunit;

namespace Organizr.Test.MapperTests;

public class MapperTests
{
    private readonly IMapper _mapper;

    public MapperTests()
    {
        _mapper = MockSetup.GetMapper();
    }

    [Fact]
    public void TestAutoMapperObjects()
    {
        // Arrange
        var user = new OrganizrUser {FirstName = "User", LastName = "Testesen"};
        var createUserCommand = new CreateUserCommand {FirstName = "UserCommand", LastName = "Teztezen"};

        var userGroup = new UserGroup {Name = "Group", Open = false};
        var createGroupCommand = new CreateUserGroupCommand { Name = "GroupCommand", Open = true};

        // Act
        var commandToUser = _mapper.Map<OrganizrUser>(createUserCommand);
        var userToCommand = _mapper.Map<CreateUserCommand>(user);
        var commandToGroup = _mapper.Map<UserGroup>(createGroupCommand);
        var groupToCommand = _mapper.Map<CreateUserGroupCommand>(userGroup);

        // Assert
        userToCommand.ShouldBeOfType<CreateUserCommand>();
        userToCommand.FirstName.ShouldBe("User");
        userToCommand.LastName.ShouldBe("Testesen");
        
        commandToUser.ShouldBeOfType<OrganizrUser>();
        commandToUser.FirstName.ShouldBe("UserCommand");
        commandToUser.LastName.ShouldBe("Teztezen");

        groupToCommand.ShouldBeOfType<CreateUserGroupCommand>();
        groupToCommand.Name.ShouldBe("Group");
        groupToCommand.Open.ShouldBe(false);
        
        commandToGroup.ShouldBeOfType<UserGroup>();
        commandToGroup.Name.ShouldBe("GroupCommand");
        commandToGroup.Open.ShouldBe(true);
    }
}