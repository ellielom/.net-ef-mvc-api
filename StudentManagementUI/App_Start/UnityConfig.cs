using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using StudentManagementUI.Models;

namespace StudentManagementUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IStudentRepo, StudentRepoEF>();
            //container.RegisterType<IStudentRepo, StudentRepoJson>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}