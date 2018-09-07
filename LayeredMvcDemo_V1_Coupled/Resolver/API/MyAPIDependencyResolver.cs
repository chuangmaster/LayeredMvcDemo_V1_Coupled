using LayeredMvcDemo.Application;
using LayeredMvcDemo_V1_Coupled.Controllers.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace LayeredMvcDemo_V1_Coupled.Resolver.API
{
    public class MyAPIDependencyResolver : IDependencyResolver
    {
        IUnityContainer _container;
        public MyAPIDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {

        }

        public object GetService(Type serviceType)
        {
            System.Diagnostics.Debug.WriteLine(serviceType.FullName);

            if (typeof(CustomerController) == serviceType)
            {
                var service = _container.Resolve<CustomerService>();
                return new CustomerController(service);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }
    }
}