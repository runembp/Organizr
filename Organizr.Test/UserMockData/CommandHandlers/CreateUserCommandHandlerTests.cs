using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Responses;
using Organizr.Core.Enums;
using Organizr.Core.Repositories;
using Organizr.Test.MockData;
using Shouldly;
using Xunit;

namespace Organizr.Test.UserMockData.CommandHandlers
{
    public class CreateUserCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _mockUow;
        private readonly CreateUserCommand _organizrUserCommand;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _mockUow = MockSetup.GetUnitOfWork();
            _mapper = MockSetup.GetMapper();
            
            _handler = new CreateUserCommandHandler(_mockUow, _mapper);

            _organizrUserCommand = new CreateUserCommand
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "emailtest@test.dk",
                PhoneNumber = "12345678",
                Address = "Testvej 12 9430 Vadum",
                Password = "Password1+",
                Gender = Gender.Undefined
            };
        }


        [Fact]
        public async Task Valid_OrganizrUser_Added()
        {
            var users = await _mockUow.OrganizrUserRepository.GetAll();
            var result = await _handler.Handle(_organizrUserCommand, CancellationToken.None);
            
            result.ShouldBeOfType<CreateUserResponse>();
            result.Succeeded.ShouldBe(true);
        }
    }
}