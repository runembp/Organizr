using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Domain.Enums;
using Organizr.Test.MockData;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Organizr.Application.Commands.Members;
using Xunit;
using Organizr.Application.Responses.Member;

namespace Organizr.Test.MemberMockData.CommandHandlers
{
    public class CreateMemberCommandHandlerTests
    {
        private readonly CreateMemberCommand _organizrMemberCommand;
        private readonly CreateMemberCommandHandler _handler;

        public CreateMemberCommandHandlerTests()
        {
            var mockUow = MockSetup.GetUnitOfWork();
            var mapper = MockSetup.GetMapper();

            _handler = new CreateMemberCommandHandler(mockUow, mapper);

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
            result.ShouldNotBeNull();
        }
    }
}