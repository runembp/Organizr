using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Handlers.RequestHandlers;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.IRepositories;
using Organizr.Test.MockData;
using Shouldly;
using Xunit;

namespace Organizr.Test.GroupMockData.RequestHandlers;

public class RequestMemberGroupHandler
{
    private readonly IUnitOfWork _mockUnitOfWork;
    private readonly GetAllMemberGroupsHandler _requestHandler;
    
    public RequestMemberGroupHandler()
    {
        _mockUnitOfWork = MockSetup.GetUnitOfWork();
        _requestHandler = new GetAllMemberGroupsHandler(_mockUnitOfWork);
    }

    [Fact]
    public async Task Valid_MemberGroup_Added()
    {
        // Arrange
        var emptyMemberGroupResponse = new GetAllMemberGroupsResponse(); 
        
        // Act
        var result = await _requestHandler.Handle(new GetAllMemberGroupsRequest(), CancellationToken.None);
        
        // Assert
        result.ShouldBeOfType<GetAllMemberGroupsResponse>();
        result.MemberGroups.ShouldBeOfType<List<MemberGroup>>();
        result.ShouldNotBe(emptyMemberGroupResponse);
        result.MemberGroups.Count.ShouldBe(3);
    }
}