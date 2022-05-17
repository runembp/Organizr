using Organizr.Test.MockData;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Handlers.CommandHandlers.Groups;
using Xunit;
using Organizr.Application.Responses.Groups;

namespace Organizr.Test.GroupMockData.CommandHandlers;

public class CreateMemberGroupHandlerTests
{
    private readonly CreateMemberGroupCommandHandler _commandHandler;

    public CreateMemberGroupHandlerTests()
    {
        var mockUnitOfWork = MockSetup.GetUnitOfWork();
        _commandHandler = new CreateMemberGroupCommandHandler(mockUnitOfWork, MockSetup.GetMapper());
    }

    [Fact]
    public async Task Valid_MemberGroup_Added()
    {
        // Arrange
        var createMemberCommand = new CreateMemberGroupCommand();

        // Act
        var result = await _commandHandler.Handle(createMemberCommand, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<CreateMemberGroupResponse>();
        result.ShouldNotBeNull();
    }
}