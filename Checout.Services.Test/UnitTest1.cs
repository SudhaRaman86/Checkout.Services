using Checkout.Services.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Checout.Services.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testProducts = GetTestProducts();
          //  var controller = new CheckoutController(testProducts);
        }

        private List<Product> GetTestProducts()
        {
            var testProducts = new List<Product>();
            testProducts.Add(new Product() { model = "001", unitPrice = 100, hasDiscount = true, forUnits = 3, discountPrice = 200 });
            testProducts.Add(new Product() { model = "002", unitPrice = 80, hasDiscount = true, forUnits = 2, discountPrice = 120 });
            testProducts.Add(new Product() { model = "003", hasDiscount = false, unitPrice = 50 });
            testProducts.Add(new Product() { model = "004", hasDiscount = false, unitPrice = 30 });
            return testProducts;
        }
    }
}
