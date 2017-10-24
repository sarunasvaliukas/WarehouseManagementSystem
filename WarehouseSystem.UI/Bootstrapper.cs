using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using WarehouseSystem.Repository;
using WarehouseSystem.Repository.Implemanations;
using WarehouseSystem.Repository.Interfaces;
using WarehouseSystem.UI.Helpers;
using WarehouseSystem.UI.Helpers.Implementations;
using WarehouseSystem.UI.Helpers.Interfaces;

namespace WarehouseSystem.UI
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            IDependencyResolver resolver = DependencyResolver.Current;
            DependencyResolver.SetResolver(new UnityDependencyResolver(container, resolver));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductHelper, ProductHelper>();
            container.RegisterType<IManufacturerRepository, ManufacturerRepository>();
            container.RegisterType<IManufacturerHelper, ManufcaturerHelper>();
            container.RegisterType<IWarehouseRepository, WarehouseRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IOrderHelper, OrderHelper>();
        }
    }

    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;

        private readonly IDependencyResolver resolver;

        public UnityDependencyResolver(IUnityContainer container, IDependencyResolver resolver)
        {
            this.container = container;
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                return resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch
            {
                return resolver.GetServices(serviceType);
            }
        }
    }
}