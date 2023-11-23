using Moq;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Services.Test
{
    internal class MockRepositoryWrapper
    {
        public static Mock<IRepository> GetMock()
        {
            var mock = new Mock<IRepository>();
            // Setup the mock
            int price = 360;
           // mock.Setup(m => m.Checkout(It.IsAny<List<string>>())).ReturnsAsync(price);
            return mock;
        }
    }
}
