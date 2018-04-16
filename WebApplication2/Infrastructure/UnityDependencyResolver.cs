using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

namespace WebApplication2.Infrastructure
{
    public class UnityDependencyResolver : IDependencyResolver
    {

        private IUnityContainer unityContainer;
        public UnityDependencyResolver(IUnityContainer container)
        {
            unityContainer = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return unityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return unityContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {

                return new List<object>();
            }
        }
    }
}