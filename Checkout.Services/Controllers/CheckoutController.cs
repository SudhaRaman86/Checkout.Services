using Microsoft.AspNetCore.Mvc;

namespace Checkout.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        public CheckoutController(ILogger<CheckoutController> logger )
        {
            _logger = logger;
        }

        [HttpPost]
        public int Checkout()
        {
            int price = 100;
            return price;
        }
    }
}
