using System.Collections.Generic;
using Models.ViewModels;

namespace Services.Home
{
    public interface INewestAdvertService
    {
        IEnumerable<NewestAdvert> GetNewest(int count);
    }
}