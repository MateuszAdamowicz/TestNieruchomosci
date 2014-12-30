using System.Web.Mvc;
using log4net;
using Services.LogService.Implementation;

namespace nieruchomości.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, ILog logger)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionLoggingFilter(logger));
        } 
    }
}