﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Requests
{
    internal class CheckoutRequest
    {
         /// <summary>
         /// List of product selected for checkout
         /// </summary>
         public List<string> product { get; set; }
    }
}
