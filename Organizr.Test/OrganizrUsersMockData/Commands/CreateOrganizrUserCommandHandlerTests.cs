using AutoMapper;
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
    public class CreateOrganizrUserCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateOrganizrUserCommand _organizrUserCommand;
        private readonly CreateOrganizrUserHandler _handler;

        public CreateOrganizrUserCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<OrganizrUserMappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateOrganizrUserHandler(_mockUow.Object, _mapper);

            _organizrUserCommand = new CreateOrganizrUserCommand
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

            result.ShouldBeOfType<OrganizrUserResponse>();

            users.Count.ShouldBe(3);

        }


    }
}
