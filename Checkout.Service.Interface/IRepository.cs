using Service.Interface.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Interface
{
     public interface IRepository
    {
        Task<CheckoutResponse> Checkout(List<string> product, CancellationToken cancellationToken =default);
    }
}
