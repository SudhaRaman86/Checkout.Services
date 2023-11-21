using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Interfaces;
using Checkout.Services.Model;
using System.Threading;
using Checkout.Services.Utils;
using Microsoft.Extensions.Logging;
using System.Runtime.Remoting.Contexts;

namespace Checkout.Repositoriess
{
    public class Repository : IRepository
    {
        private readonly ILogger _logger;
        private readonly AppDbContext _context;
        public Repository(AppDbContext context, ILogger<Repository> logger)
        {
            //need to set up the extensions methods for exceptions, to catch if there is any null values passed
           // ParamUtil.CheckIsNotNull(context, nameof(context));
           // ParamUtil.CheckIsNotNull(context, nameof(logger));
           // ParamUtil.CheckIsNotNull(context, nameof(mapper)); 

            _context = context;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<int> Checkout(List<string> products, CancellationToken cancellationToken)
        {
            //logging
            _logger.LogInformation(Constants.TEMPLATE_INVOKE_WITH_PARAM, nameof(Checkout), nameof(products), products);

            //Setting up the productdetails here instead of calling db for each model inside the loop below
            //AppDbContext's Dbset ProductDiscount is the table which has columns modelname, unitprice, hasiscount, forunits, discountprice
            ProductDetail _rolex = new ProductDetail() { model = "001", unitPrice = 100, hasDiscount = true, forUnits = 3, discountPrice = 200 };
            ProductDetail _mKors = new ProductDetail() { model = "002", unitPrice = 80, hasDiscount = true, forUnits = 2, discountPrice = 120 };
            ProductDetail _swatch = new ProductDetail() { model = "003", hasDiscount = false, unitPrice = 50 };
            ProductDetail _casio = new ProductDetail() { model = "004", hasDiscount = false, unitPrice = 30 };
            List<ProductDetail> ModelUnitPriceAndDiscountDetails = new List<ProductDetail> { _rolex, _mKors, _swatch, _casio };
            
            // Begin calculation
            int totalAmount = 0;
            Dictionary<string, int> modelAndCounts = products.GroupBy(x => x)
                                                    .ToDictionary(g => g.Key,
                                                                g => g.Count());
            foreach (var m in modelAndCounts)
            {
                int modelTotalPrice = 0;
                var _modelDetails = ModelUnitPriceAndDiscountDetails.Where(x => x.model.Equals(m.Key)).FirstOrDefault();
                // this would be a call to AppDbcontext's ProductDetail
                //var matchingmodel = await _context.ProductDetail
                //                               .AsNoTracking()
                //                               .Where(id => id.model == m )
                //                               .FirstOrDefaultAsync(cancellationToken);
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
