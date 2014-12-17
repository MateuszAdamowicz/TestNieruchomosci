using Models.ApplicationModels;
using Models.ViewModels;

namespace Services.Home.EmailService
{
    public interface IShowAdvertService
    {
        Result<ShowAdvert> GetAdvert(AdType adType, int id);
    }
}