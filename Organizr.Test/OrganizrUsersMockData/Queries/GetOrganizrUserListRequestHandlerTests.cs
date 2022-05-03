﻿using AutoMapper;
using Moq;
using Organizr.Application.Handlers.RequestHandlers;
using Organizr.Application.Mapper;
using Organizr.Application.Requests;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Test.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Organizr.Test.OrganizrUsersMockData.Queries
{
    public class GetOrganizrUserListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepo;

        public GetOrganizrUserListRequestHandlerTests()
        {
            _mockRepo = MockOrganizrUserRepository.GetOrganizrUserRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<OrganizrUserMappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetOrganizrUserListTest()
        {
            var handler = new GetAllOrganizrUserHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetAllOrganizrUserRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<OrganizrUser>>();

            result.Count.ShouldBe(2);

        }


    }
}
