using BLL;
using DAL;
using Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WEB
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ApplicationDBContext>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IcategoryService, CategoryService>();

            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}