using System.Configuration;
using System.Web;
using System.Web.Security;
using Models.ViewModels;

namespace Services.Admin
{
    public class AdminLoginService : IAdminLoginService
    {
        public LoginViewModel Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Login == ConfigurationManager.AppSettings["adminLogin"] &&
                loginViewModel.Password == ConfigurationManager.AppSettings["adminPassword"])
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