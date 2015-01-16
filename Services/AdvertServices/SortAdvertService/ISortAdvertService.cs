using System.Collections.Generic;
using Models.ViewModels;

namespace Services.AdvertServices.SortAdvertService.Implementation
{
    public interface ISortAdvertService
    {
        List<ShowAdvertList> SortAdverts(List<ShowAdvertList> adverts, SortOption? sortOption);
    }
}