using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Context;
using log4net;
using log4net.Config;
using nieruchomości.Migrations;
using Services.StatisticesServices.StatisticesService;

namespace nieruchomości
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Initialise();


            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationContext>());
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            ILog logger = LogManager.GetLogger("Log4NetTest.OtherClass");
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, logger);            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Context.Migrations.Configuration>());
            MapperConfig.Register();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Visited"] = new List<int>();

            var statisticesService = DependencyResolver.Current.GetService<IStatisticesService>();

            statisticesService.AddDailyUser(Session.SessionID);
        }
    }
}
