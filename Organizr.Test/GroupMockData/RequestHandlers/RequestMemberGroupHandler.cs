using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Responses.Groups;
using Organizr.Domain.Entities;
using Organizr.Test.MockData;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Handlers.RequestHandlers.Groups;
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