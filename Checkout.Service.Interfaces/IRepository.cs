using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Interfaces
{
     public interface IRepository
    {
        Task<int> Checkout(List<string> product, CancellationToken cancellationToken);
    }
}
