using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Commands;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Responses;
using Organizr.Core.Enums;
using Organizr.Core.Repositories;
using Organizr.Test.MockData;
using Shouldly;
using Xunit;

namespace Organizr.Test.MemberMockData.CommandHandlers
{
    public class CreateMemberCommandHandlerTests
    {
        private readonly IUnitOfWork _mockUow;
        private readonly CreateMemberCommand _organizrMemberCommand;
        private readonly CreateMemberCommandHandler _handler;

        public CreateMemberCommandHandlerTests()
        {
            _mockUow = MockSetup.GetUnitOfWork();
            var mapper = MockSetup.GetMapper();
            
            _handler = new CreateMemberCommandHandler(_mockUow, mapper);

            _organizrMemberCommand = new CreateMemberCommand
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
        public async Task Valid_Member_Added()
        {
            var result = await _handler.Handle(_organizrMemberCommand, CancellationToken.None);
            
            result.ShouldBeOfType<CreateMemberResponse>();
            result.Succeeded.ShouldBe(true);
            result.Errors.Count.ShouldBe(0);
        }
    }
}