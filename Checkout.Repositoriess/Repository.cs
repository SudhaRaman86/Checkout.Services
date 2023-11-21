using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Interfaces;
using Checkout.Services.Model;
using System.Threading;

namespace Checkout.Repositoriess
{
    public class Repository : IRepository
    {
        public Repository()
        { 

        }
        public async Task<int> Checkout(List<string> products, CancellationToken cancellationToken)
        {
            Product _rolex = new Product() { model = "001", unitPrice = 100, hasDiscount = true, forUnits = 3, discountPrice = 200 };
            Product _mKors = new Product() { model = "002", unitPrice = 80, hasDiscount = true, forUnits = 2, discountPrice = 120 };
            Product _swatch = new Product() { model = "003", hasDiscount = false, unitPrice = 50 };
            Product _casio = new Product() { model = "004", hasDiscount = false, unitPrice = 30 };

            List<Product> ModelUnitPriceAndDiscountDetails = new List<Product> { _rolex, _mKors, _swatch, _casio };
            int totalAmount = 0;

            Dictionary<string, int> modelAndCounts = products.GroupBy(x => x)
                                                    .ToDictionary(g => g.Key,
                                                                g => g.Count());

            foreach (var m in modelAndCounts)
            {
                int modelTotalPrice = 0;
                var _modelDetails = ModelUnitPriceAndDiscountDetails.Where(x => x.model.Equals(m.Key)).FirstOrDefault();
                if (_modelDetails != null)
                {
                    if (_modelDetails.hasDiscount)
                    {
                        int q = m.Value / _modelDetails.forUnits.Value;
                        int r = m.Value % _modelDetails.forUnits.Value;
                        modelTotalPrice = q * (int)_modelDetails.discountPrice + r * _modelDetails.unitPrice;
                    }
                    else
                    {
                        modelTotalPrice = _modelDetails.unitPrice * m.Value;
                    }
                }
                totalAmount += modelTotalPrice;
            }
            return totalAmount;            
        }

       
    }
}
