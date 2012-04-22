using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MarkPadServer
{
    using Autofac;
    using Autofac.Core;
    using Autofac.Integration.Mvc;

    using MarkPadServer.PageStore;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "MdPage",
                url: "page/{name}",
                defaults: new { controller = "Pages", action = "ViewPage" }
            );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            builder.RegisterType<FileSystemPageStore>().WithParameter("directory", Server.MapPath("~/MdPages"));
            builder.RegisterType<MarkDownPageStore>().As<IPageStore>()
                .WithParameter(
                new ResolvedParameter(
                    (p, c) => p.ParameterType == typeof(IPageStore), 
                    (p, c) => c.Resolve<FileSystemPageStore>()));

            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            BundleTable.Bundles.RegisterTemplateBundles();
        }
    }
}