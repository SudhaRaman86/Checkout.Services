using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Service.Interfaces;
using System;
using System.Reflection;

namespace Checkout.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly IRepository _repository;
        public CheckoutController(ILogger<CheckoutController> logger, IRepository repository )
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<int> Checkout( List<String> products, CancellationToken cancellationToken = default)
        {
            // _logger.LogInformation(Constants.TEMPLATE_INVOKE_WITH_PARAM, nameof(Checkout), nameof(filter), filter.ToJSON());
            //Check list is not null
            return await _repository.Checkout(products, cancellationToken);
        }
    }
}
