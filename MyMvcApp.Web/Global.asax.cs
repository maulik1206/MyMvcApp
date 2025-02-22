using AutoMapper;
using MyMvcApp.Application;
using MyMvcApp.Application.Interfaces;
using MyMvcApp.Application.Services;
using MyMvcApp.Infrastructure.Repositories;
using MyMvcApp.Infrastructure.UnitOfWork;
using MyMvcApp.Web.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace MyMvcApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<UserService>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            container.RegisterInstance(mapper);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            GlobalFilters.Filters.Add(new GlobalExceptionFilter());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest()
        {
            if (Response.StatusCode == 401)
            {
                Response.Redirect("~/Account/Login");
            }
        }
    }
}
