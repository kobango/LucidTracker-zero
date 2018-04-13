using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using Unity;
using WebApplication2.Database;

namespace WebApplication2.Infrastructure
{
    public class DI_Configurator
    {
        public static IUnityContainer Initialise()
        {
            var container = new UnityContainer();

            container.RegisterInstance(new LucidTrackerDbContext());
            //container.RegisterType<IHoursRepository, HoursRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
    }
}