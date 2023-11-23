using Checkout.Service.Model;
using Checkout.Services.Controllers;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
       
            public void TestMethod1()
            {
                var testProducts = GetTestProducts();
                //var controller = new CheckoutController(testProducts);
            //var result = await controller.GetAllProductsAsync() as List<Product>;
            //Assert.AreEqual(testProducts.Count, result.Count);
        }

            private List<ProductDetail> GetTestProducts()
            {
                var testProducts = new List<ProductDetail>();
                testProducts.Add(new ProductDetail() { model = "001", unitPrice = 100, hasDiscount = true, forUnits = 3, discountPrice = 200 });
                testProducts.Add(new ProductDetail() { model = "002", unitPrice = 80, hasDiscount = true, forUnits = 2, discountPrice = 120 });
                testProducts.Add(new ProductDetail() { model = "003", hasDiscount = false, unitPrice = 50 });
                testProducts.Add(new ProductDetail() { model = "004", hasDiscount = false, unitPrice = 30 });
                return testProducts;
            }
        
    }
}