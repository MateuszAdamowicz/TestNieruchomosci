using Models.ApplicationModels;
using Models.ViewModels;

namespace Services.AdvertServices.ShowAdvertService
{
    public interface IShowAdvertService
    {
        Result<ShowAdvert> GetAdvert(AdType adType, int id);
    }
}