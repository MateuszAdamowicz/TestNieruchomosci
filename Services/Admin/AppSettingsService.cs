using System.Configuration;

namespace Services.Admin
{
    public class AppSettingsService : IAppSettingsService
    {
        public string GetKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        } 
    }
}