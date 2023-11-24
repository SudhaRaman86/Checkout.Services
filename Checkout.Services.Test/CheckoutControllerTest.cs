using Checkout.Service.Model;
using Checkout.Services.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Service.Interface;
using Service.Interface.Responses;

namespace Checkout.Services.Test
{
    [TestClass]
    public class CheckoutControllerTest
    {
        private readonly ILogger<CheckoutController> _logger;
        Mock<IRepository> _mockRepo = new Mock<IRepository>();
        List<ProductDetail> _mockProductDetail;
        CheckoutController _controller;
        CancellationTokenSource _cts = new CancellationTokenSource();
        public CheckoutControllerTest()
        {
            ProductDetail _rolex = new ProductDetail() { model = "001", unitPrice = 100, hasDiscount = true, forUnits = 3, discountPrice = 200 };
            ProductDetail _mKors = new ProductDetail() { model = "002", unitPrice = 80, hasDiscount = true, forUnits = 2, discountPrice = 120 };
            ProductDetail _swatch = new ProductDetail() { model = "003", hasDiscount = false, unitPrice = 50 };
            ProductDetail _casio = new ProductDetail() { model = "004", hasDiscount = false, unitPrice = 30 };
            _mockProductDetail = new List<ProductDetail> { _rolex, _mKors, _swatch, _casio };

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
            _mockRepo.Setup(m => m.setProductDetails());
            _controller = new CheckoutController(_mockRepo.Object, _logger);
            
            //act
            var actualResult = _controller.checkout(modelList).Result;
            ////assert
            Assert.AreEqual(expectedResult, actualResult);
        }       
    }
}
