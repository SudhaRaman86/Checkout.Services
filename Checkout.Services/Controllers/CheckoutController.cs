using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Services.Interfaces.Requests;

namespace Checkout.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly IRepository _repository;
        List<CheckoutRequest> products;

        public CheckoutController(ILogger<CheckoutController> logger, IRepository repository )
        {
            _logger = logger;
            _repository = repository;
        }

        public CheckoutController(List<CheckoutRequest> products)
        {
            this.products = products;
        }

        [HttpPost]
        public async Task<int> Checkout(List<string> products, CancellationToken cancellationToken = default)
        {
            // _logger.LogInformation(Constants.TEMPLATE_INVOKE_WITH_PARAM, nameof(Checkout), nameof(filter), filter.ToJSON());
            //Check list is not null
            return await _repository.Checkout(products, cancellationToken);
        }
    }
}
