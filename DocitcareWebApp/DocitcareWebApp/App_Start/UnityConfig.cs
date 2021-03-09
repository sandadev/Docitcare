using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using DocitcareWebApp.Core.Repositories;
using DocitcareWebApp.Persistence.Repositories;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core;
using DocitcareWebApp.Persistence;

namespace DocitcareWebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();


            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}