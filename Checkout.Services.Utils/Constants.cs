using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Services.Utils
{
    public class Constants
    {
        public const string TEMPLATE_INVOKE_WITH_PARAM = "Invoking {MethodName} method for {ParamName}: [{@ParamData}]";
        public const string TEMPLATE_INVOKE_WITH_PARAM_PAGE = "Invoking {MethodName} method for {ParamName}: [{@ParamData}] of {page} [{@PageNo}] with {pagesize} [{@PageSize}]";
        public const string TEMPLATE_RETURN = "{MethodName} method completed";
        public const string TEMPLATE_RETURN_WITH_DATA = "{MethodName} method returning {@ResponseData}";

        public const string VALIDATE_MESSAGE = "XXX";
    }
}
