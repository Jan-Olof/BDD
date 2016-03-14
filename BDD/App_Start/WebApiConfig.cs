using BDD.Models;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace BDD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config = ConfigureDependencyInjection(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        /// <summary>
        /// Configure dependency injection.
        /// </summary>
        private static HttpConfiguration ConfigureDependencyInjection(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<ICalculationModel, CalculationModel>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            return config;
        }
    }
}