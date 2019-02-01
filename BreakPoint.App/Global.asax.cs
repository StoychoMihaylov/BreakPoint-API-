using AutoMapper;
using BreakPoint.Data.EntityModels;
using BreakPoint.Models.ViewModels.Profile;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BreakPoint.App
{

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMapper();
            ConfigureReferenceLoopHandlingInEF();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);   
        }

        private void ConfigureReferenceLoopHandlingInEF()
        {
            GlobalConfiguration
               .Configuration
               .Formatters
               .JsonFormatter
               .SerializerSettings
               .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration
                .Configuration
                .Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<AuthenticationUser, UserProfileViewModel>();
            });
        }
    }
}
