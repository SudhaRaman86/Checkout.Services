using AutoFixture;
using Castle.Core.Logging;
using Checkout.Service.Model;
using Checkout.Services.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.OpenApi.Writers;
using Moq;
using Service.Interface;
using Service.Interface.Responses;
using System.Drawing.Text;
using System.Net;
using System.Threading;

namespace Checkout.Services.Test
{
    [TestClass]
    public class CheckoutControllerTest
    {
        private readonly ILogger<CheckoutController> _logger;
        Mock<IRepository> _mockRepo = new Mock<IRepository>();
        CheckoutController _controller;
        CancellationTokenSource _cts = new CancellationTokenSource();
        public CheckoutControllerTest()
        {            
                   
        }
       
        [TestMethod]
        public async Task checkoutTest()
        {
            var token = _cts.Token;
            CheckoutResponse response = new CheckoutResponse();
            response.price = 360;
            var expectedResult = response;
            //arrange
            List<string> modelList = new List<string>() { "001", "002", "001", "004", "003" };
            _mockRepo.Setup(m => m.Checkout(modelList, token)).ReturnsAsync(response);
            _controller = new CheckoutController(_mockRepo.Object, _logger);
            //act
            var actualResult = _controller.checkout(modelList).Result;
            ////assert
            Assert.AreEqual(expectedResult, actualResult);
        }       
    }
}
