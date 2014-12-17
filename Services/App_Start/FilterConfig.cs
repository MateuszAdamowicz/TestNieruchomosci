using System.Web.Mvc;
using log4net;
using Services.Admin.LogService;

namespace Services.App_Start
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