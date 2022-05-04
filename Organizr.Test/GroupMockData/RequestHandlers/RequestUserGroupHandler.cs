using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Commands;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Handlers.RequestHandlers;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Test.MockData;
using Shouldly;
using Xunit;

namespace Organizr.Test.GroupMockData.RequestHandlers;

public class RequestUserGroupHandler
{
    private readonly IUnitOfWork _mockUnitOfWork;
    private readonly GetAllUserGroupsHandler _requestHandler;
    
    public RequestUserGroupHandler()
    {
        _mockUnitOfWork = MockSetup.GetUnitOfWork();
        _requestHandler = new GetAllUserGroupsHandler(_mockUnitOfWork);
    }

    [Fact]
    public async Task Valid_UserGroup_Added()
    {
        // Arrange
        var emptyUserGroupResponse = new GetAllUserGroupsResponse(); 
        
        // Act
        var result = await _requestHandler.Handle(new GetAllUserGroupsRequest(), CancellationToken.None);
        
        // Assert
        result.ShouldBeOfType<GetAllUserGroupsResponse>();
        result.UserGroups.ShouldBeOfType<List<UserGroup>>();
        result.ShouldNotBe(emptyUserGroupResponse);
        result.UserGroups.Count.ShouldBe(3);
    }
}