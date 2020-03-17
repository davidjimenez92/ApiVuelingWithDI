using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace Vueling.Business.Facade.Filters
{
	public class NullReferenceExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			if (actionExecutedContext.Exception is NullReferenceException)
			{
				var httpResponseMessage =
					new HttpResponseMessage(HttpStatusCode.InternalServerError)
					{
						Content = new StringContent(actionExecutedContext.Exception.Message, Encoding.UTF8, "text/plain"),
						StatusCode = HttpStatusCode.InternalServerError,
						ReasonPhrase = "Null Reference Error"
					};

				actionExecutedContext.Response = httpResponseMessage;
			}

			base.OnException(actionExecutedContext);
		}
	}
}