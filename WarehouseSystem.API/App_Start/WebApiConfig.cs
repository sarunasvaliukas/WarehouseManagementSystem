using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using WarehouseSystem.Repository;
using WarehouseSystem.Repository.Implemanations;
using WarehouseSystem.Repository.Interfaces;

namespace WarehouseSystem.API
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



            var container = new UnityContainer();
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
