﻿using AutoMapper;
using Moq;
using Organizr.Application.Commands;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Mapper;
using Organizr.Application.Responses;
using Organizr.Core.Enums;
using Organizr.Core.Repositories;
using Organizr.Test.Mocks;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Organizr.Test.OrganizrUsersMockData.Commands
{
    public class CreateUserCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateUserCommand _organizrUserCommand;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<OrganizrMappingProfiler>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateUserCommandHandler(_mockUow.Object, _mapper);

            _organizrUserCommand = new CreateUserCommand
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "emailtest",
                PhoneNumber = "12345678",
                Address = "Testvej 12 9430 Vadum",
                Password = "password",
                Gender = Gender.Undefined
            };
        }


        [Fact]
        public async Task Valid_OrganizrUser_Added()
        {
            var result = await _handler.Handle(_organizrUserCommand, CancellationToken.None);
            var users = await _mockUow.Object.OrganizrUserRepository.GetAll();

            result.ShouldBeOfType<CreateUserResponse>();

            users.Count.ShouldBe(3);

        }


    }
}
