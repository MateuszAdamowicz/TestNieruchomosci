using Models.ApplicationModels;
using Models.ViewModels;

namespace Services.AdvertServices.AddAdvertService
{
    public interface IAddAdvertService
    {
        Result<string> AddFlat(AdminFlat adminFlat);
        Result<string> AddLand(AdminLand adminLand);
        Result<string> AddHouse(AdminHouse adminHouse);
    }
}