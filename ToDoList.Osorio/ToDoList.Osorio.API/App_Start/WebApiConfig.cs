using System.Web.Http;
using ToDoList.Core.Infrastructure.NH;
using System.Web.Http.Cors;


namespace ToDoList.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            SwaggerConfig.Register();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            //NH
            NHConfig.Configure();

            //DryIOC
            DependencyInjection.Configure(config);
        }
    }
}
