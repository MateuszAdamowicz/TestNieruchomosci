using Context;
using Microsoft.Practices.Unity;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using Services.Admin;
using Services.Home;
using Services.Home.EmailService;

namespace Services.App_Start
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IApplicationContext, ApplicationContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddAdvertService, AddAdvertService>();
            container.RegisterType<IPhotoService, PhotoService>();
            container.RegisterType<IWorkerService, WorkerService>();
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<IEmailService, EmailService>();
            container.RegisterType<ITemplateServiceConfiguration, TemplateServiceConfiguration>();
            container.RegisterType<IUpdateAdvertService, UpdateAdvertService>();
            container.RegisterType<ISearchService, SearchService>();
            container.RegisterType<ISmtpManager, SmtpManager>();
            container.RegisterType<IEmailSenderService, EmailSenderService>();
            container.RegisterType<IEmailStorageService, EmailStorageService>();
            container.RegisterType<IShowAdvertService, ShowAdvertService>();
            container.RegisterType<IAdminLoginService, AdminLoginService>();
            container.RegisterType<ICounterService, CounterService>();
            container.RegisterType<INewestAdvertService, NewestAdvertService>();
            container.RegisterType<IStatisticesService, StatisticesService>();
            container.RegisterType<IAdminFilterService, AdminFilterService>();
            container.RegisterType<IAppSettingsService, AppSettingsService>();
        }
    }
}