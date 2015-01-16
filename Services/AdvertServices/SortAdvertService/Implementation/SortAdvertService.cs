using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using Models.ViewModels;

namespace Services.AdvertServices.SortAdvertService.Implementation
{
    public class SortAdvertService : ISortAdvertService
    {
        public List<ShowAdvertList> SortAdverts(List<ShowAdvertList> adverts, SortOption? sortOption)
        {
            switch (sortOption)
            {
                case SortOption.PriceDesc:
                    return adverts.OrderByDescending(elem => elem.Price).ToList();

               case SortOption.PriceAsc:
                    return adverts.OrderBy(elem => elem.Price).ToList();

                case SortOption.DateDesc:
                    return adverts.OrderByDescending(elem => elem.CreatedAt).ToList();                
                
                case SortOption.DateAsc:
                    return adverts.OrderBy(elem => elem.CreatedAt).ToList();
                
                case SortOption.CityDesc:
                    return adverts.OrderByDescending(elem => elem.CreatedAt).ToList();

                case SortOption.CityAsc:
                    return adverts.OrderBy(elem => elem.CreatedAt).ToList();

                default:
                    return adverts;
            }
        }
    }
}