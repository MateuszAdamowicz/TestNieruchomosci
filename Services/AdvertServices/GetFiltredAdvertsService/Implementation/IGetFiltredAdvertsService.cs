using System.Collections.Generic;
using Models.ViewModels;

namespace Services.AdvertServices.GetFiltredAdvertsService.Implementation
{
    public interface IGetFiltredAdvertsService
    {
        List<ShowAdvertList> GetAdverts(AdType? adType, string flatCities, int? flatRooms, string houseCities,
            string landCities, string allCities, int? priceFrom, int? priceTo, SortOption? sortOption);
    }
}