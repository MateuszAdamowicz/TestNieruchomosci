using System.Web;
using Models.ViewModels;

namespace Services.AdminLoginService
{
    public interface IAdminLoginService
    {
        LoginViewModel Login(LoginViewModel loginViewModel);
        void Logout();
        void SetLoginCookies(string userName);
        HttpCookieCollection Cookies();
    }
}