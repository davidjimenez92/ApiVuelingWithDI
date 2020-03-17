using System.Web.Http;
using Vueling.Business.Facade.Filters;

namespace Vueling.Business.Facade
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new NotImplementedExceptionFilterAttribute());
            config.Filters.Add(new NullReferenceExceptionFilterAttribute());
        }
    }
}
