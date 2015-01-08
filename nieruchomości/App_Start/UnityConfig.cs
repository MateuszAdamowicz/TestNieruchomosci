using Context;
using Microsoft.Practices.Unity;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using Services.AdminLoginService;
using Services.AdvertServices.AddAdvertService;
using Services.AdvertServices.AddAdvertService.Implementation;
using Services.AdvertServices.AdminFilterAdvertService;
using Services.AdvertServices.AdminFilterAdvertService.Implementation;
using Services.AdvertServices.ChangeAdvertVisability;
using Services.AdvertServices.ChangeAdvertVisability.Implementation;
using Services.AdvertServices.GetAdvertService.Implementation;
using Services.AdvertServices.NewestAdvertService;
using Services.AdvertServices.NewestAdvertService.Implementation;
using Services.AdvertServices.ShowAdvertService;
using Services.AdvertServices.ShowAdvertService.Implementation;
using Services.AdvertServices.UpdateAdvertService;
using Services.AdvertServices.UpdateAdvertService.Implementation;
using Services.AppSettingsService;
using Services.CalcService;
using Services.CalcService.Implementation;
using Services.CreateOfferService;
using Services.CreateOfferService.Implementation;
using Services.DeleteMessageService;
using Services.EmailServices.EmailSenderService;
using Services.EmailServices.EmailSenderService.Implementation;
using Services.EmailServices.EmailService;
using Services.EmailServices.EmailService.Implementation;
using Services.EmailServices.EmailStorageService;
using Services.EmailServices.EmailStorageService.Implementation;
using Services.EmailServices.SmtpManager;
using Services.EmailServices.SmtpManager.Implementation;
using Services.GenericRepository;
using Services.PhotoService;
using Services.SearchService;
using Services.StatisticesServices.CounterService;
using Services.StatisticesServices.CounterService.Implementation;
using Services.StatisticesServices.StatisticesService;
using Services.StatisticesServices.StatisticesService.Implementation;
using Services.WorkerService;
using Services.AdminSettingsService;
using Services.AdminSettingsService.Implementation;


namespace nieruchomości
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IApplicationContext, ApplicationContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddAdvertService, AddAdvertService>();
            container.RegisterType<IPhotoService, Services.PhotoService.Implementation.PhotoService>();
            container.RegisterType<IWorkerService, Services.WorkerService.Implementation.WorkerService>();
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<IEmailService, EmailService>();
            container.RegisterType<ITemplateServiceConfiguration, TemplateServiceConfiguration>();
            container.RegisterType<IUpdateAdvertService, UpdateAdvertService>();
            container.RegisterType<ISearchService, Services.SearchService.Implementation.SearchService>();
            container.RegisterType<ISmtpManager, SmtpManager>();
            container.RegisterType<IEmailSenderService, EmailSenderService>();
            container.RegisterType<IEmailStorageService, EmailStorageService>();
            container.RegisterType<IShowAdvertService, ShowAdvertService>();
            container.RegisterType<IAdminLoginService, Services.AdminLoginService.Implementation.AdminLoginService>();
            container.RegisterType<ICounterService, CounterService>();
            container.RegisterType<INewestAdvertService, NewestAdvertService>();
            container.RegisterType<IStatisticesService, StatisticesService>();
            container.RegisterType<IAdminFilterAdvertService, AdminFilterAdvertService>();
            container.RegisterType<IAppSettingsService, Services.AppSettingsService.Implementation.AppSettingsService>();
            container.RegisterType<IOfferService, OfferService>();
            container.RegisterType<IDeleteMessageService, Services.DeleteMessageService.Implementation.DeleteMessageService>();
            container.RegisterType<IGenericRepository, Services.GenericRepository.Implementation.GenericRepository>();
            container.RegisterType<IChangeAdvertVisibility, ChangeAdvertVisibility>();
            container.RegisterType<ICalcService, CalcService>();
            container.RegisterType<IGetAdvertService, GetAdvertService>();
            container.RegisterType<IAdminSettingsService, AdminSettingsService>();
        }
    }
}