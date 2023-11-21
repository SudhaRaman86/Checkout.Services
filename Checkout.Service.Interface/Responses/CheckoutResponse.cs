using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Responses
{
    internal class CheckoutResponse
    {
        /// <summary>
        /// The total amount after checkout
        /// </summary>
        public int price { get; set; }
    }
}
