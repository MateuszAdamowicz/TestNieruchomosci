using System.Configuration;
using System.Web;
using System.Web.Security;
using Models.ViewModels;

namespace Services.Admin
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly IAppSettingsService _appSettingsService;

        public AdminLoginService(IAppSettingsService appSettingsService)
        {
            _appSettingsService = appSettingsService;
        }

        public LoginViewModel Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Login == _appSettingsService.GetKey("adminLogin") &&
                loginViewModel.Password == _appSettingsService.GetKey("adminPassword"))
            {
                loginViewModel.Authorized = true;
            }
            else
            {
                loginViewModel.Authorized = false;
            }
            return loginViewModel;
        }

        public void SetLoginCookies(string userName)
        {
            FormsAuthentication.SetAuthCookie(userName,false);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public HttpCookieCollection Cookies()
        {
            return HttpContext.Current.Response.Cookies;
        }
    }
}