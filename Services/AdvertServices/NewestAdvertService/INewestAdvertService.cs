using System.Collections.Generic;
using Models.ViewModels;

namespace Services.AdvertServices.NewestAdvertService
{
    public interface INewestAdvertService
    {
        IEnumerable<NewestAdvert> GetNewest(int count);
    }
}