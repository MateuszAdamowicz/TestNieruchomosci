using System.Configuration;

namespace Services.AppSettingsService.Implementation
{
    public class AppSettingsService : IAppSettingsService
    {
        public string GetKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        } 
    }
}