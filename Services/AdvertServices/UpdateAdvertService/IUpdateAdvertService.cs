using Models.ApplicationModels;
using Models.ViewModels;

namespace Services.AdvertServices.UpdateAdvertService
{
    public interface IUpdateAdvertService
    {
        Result UpdateFlat(EditFlat editFlat, int id);
        Result UpdateHouse(EditHouse editHouse, int id);
        Result UpdateLand(EditLand editLand, int id);
    }
}