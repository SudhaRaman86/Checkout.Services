using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Interface.Requests;
using Service.Interface.Responses;

namespace Checkout.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly IRepository _repository;
      
        public CheckoutController(IRepository repository, ILogger<CheckoutController> logger)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<CheckoutResponse> checkout(List<string> products, CancellationToken cancellationToken = default)
        {
            // _logger.LogInformation(Constants.TEMPLATE_INVOKE_WITH_PARAM, nameof(Checkout), nameof(filter), filter.ToJSON());
            //Check list is not null
           CheckoutResponse response = await _repository.Checkout(products, cancellationToken);
           return response;
        }
    }
}
