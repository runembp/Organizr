using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Domain.Entities;
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
        var member = new Member { FirstName = "Member", LastName = "Testesen" };
        var createMemberCommand = new CreateMemberCommand { FirstName = "MemberCommand", LastName = "Teztezen" };

        var memberGroup = new MemberGroup { Name = "Group", IsOpen = false };
        var createGroupCommand = new CreateMemberGroupCommand { Name = "GroupCommand", IsOpen = true };

        // Act
        var commandToMember = _mapper.Map<Member>(createMemberCommand);
        var memberToCommand = _mapper.Map<CreateMemberCommand>(member);
        var commandToGroup = _mapper.Map<MemberGroup>(createGroupCommand);
        var groupToCommand = _mapper.Map<CreateMemberGroupCommand>(memberGroup);

        // Assert
        memberToCommand.ShouldBeOfType<CreateMemberCommand>();
        memberToCommand.FirstName.ShouldBe("Member");
        memberToCommand.LastName.ShouldBe("Testesen");

        commandToMember.ShouldBeOfType<Member>();
        commandToMember.FirstName.ShouldBe("MemberCommand");
        commandToMember.LastName.ShouldBe("Teztezen");

        groupToCommand.ShouldBeOfType<CreateMemberGroupCommand>();
        groupToCommand.Name.ShouldBe("Group");
        groupToCommand.IsOpen.ShouldBe(false);

        commandToGroup.ShouldBeOfType<MemberGroup>();
        commandToGroup.Name.ShouldBe("GroupCommand");
        commandToGroup.IsOpen.ShouldBe(true);
    }
}