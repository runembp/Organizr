using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Commands;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Responses;
using Organizr.Core.Repositories;
using Organizr.Test.MockData;
using Shouldly;
using Xunit;

namespace Organizr.Test.GroupMockData.CommandHandlers;

public class CreateUserGroupHandlerTests
{
    private readonly IUnitOfWork _mockUnitOfWork;
    private readonly CreateUserGroupCommandHandler _commandHandler;
    
    public CreateUserGroupHandlerTests()
    {
        _mockUnitOfWork = MockSetup.GetUnitOfWork();
        _commandHandler = new CreateUserGroupCommandHandler(_mockUnitOfWork, MockSetup.GetMapper());
    }

    [Fact]
    public async Task Valid_UserGroup_Added()
    {
        // Arrange
        var organizrUserCommand = new CreateUserGroupCommand();
        
        // Act
        var result = await _commandHandler.Handle(organizrUserCommand, CancellationToken.None);
        
        // Assert
        result.ShouldBeOfType<CreateUserGroupResponse>();
        result.Succeeded.ShouldBe(true);
    }
}