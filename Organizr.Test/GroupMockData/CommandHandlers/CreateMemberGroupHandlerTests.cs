using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Commands;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Responses;
using Organizr.Test.MockData;
using Shouldly;
using Xunit;

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
        result.Succeeded.ShouldBe(true);
    }
}