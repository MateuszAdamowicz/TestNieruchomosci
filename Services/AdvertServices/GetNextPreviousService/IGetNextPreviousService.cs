using Models.EntityModels;
using Models.ViewModels;

namespace Services.AdvertServices.GetNextPreviousService
{
    public interface IGetNextPreviousService
    {
        AdvertNeighbours<TT> GetNeighbours<T, TT>(int id) 
            where T : Ad
            where TT: ShowAd;
    }
}