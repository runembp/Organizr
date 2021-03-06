using AutoMapper;
using Moq;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;
using Organizr.Test.MockData;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Handlers.RequestHandlers.Members;
using Xunit;

namespace Organizr.Test.MemberMockData.Queries
{
    public class GetMemberListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMemberRepository> _mockRepo;

        public GetMemberListRequestHandlerTests()
        {
            _mockRepo = MockMemberRepository.GetMemberRepository();
            _mapper = MockSetup.GetMapper();
        }

        [Fact]
        public async Task GetMemberListTest()
        {
            var handler = new GetAllMembersHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetAllMembersRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<Member>>();
            result.Count.ShouldBe(2);
        }
    }
}