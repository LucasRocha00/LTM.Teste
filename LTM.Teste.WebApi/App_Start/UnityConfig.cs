using LTM.Teste.Business;
using LTM.Teste.Contracts.Business;
using LTM.Teste.Contracts.Repository;
using LTM.Teste.Repository.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace LTM.Teste.WebApi.App_Start
{
    public class UnityConfig : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityConfig(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityConfig(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}