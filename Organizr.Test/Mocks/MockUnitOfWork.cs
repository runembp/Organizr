using Moq;
using Organizr.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizr.Test.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();

            var organizrRepo = MockOrganizrUserRepository.GetOrganizrUserRepository();

            mockUow.Setup(r => r.OrganizrUserRepository).Returns(organizrRepo.Object);

            return mockUow;
        }
    }
}
