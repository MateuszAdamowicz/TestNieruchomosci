using Models.EntityModels;

namespace Services.AdvertServices.GetAdvertService.Implementation
{
    public interface IGetAdvertService
    {
        TT GetAdvert<T, TT>(int id, bool admin)
            where T : Ad
            where TT : class;
    }
}