using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Web.App.App_Start
{
    public class GeneralExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var StatusCode = HttpStatusCode.InternalServerError;
            context.Response = new HttpResponseMessage(StatusCode);

        }
    }
}