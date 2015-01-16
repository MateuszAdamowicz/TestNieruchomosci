using System.Collections.Generic;
using PagedList;

namespace Models.ViewModels
{
    public class IndexViewModel
    {
        public IndexFilterOptions IndexFilterOptions { get; set; }
        public IPagedList<ShowAdvertList> AdvertList { get; set; }
        public IndexFiltred IndexFiltred { get; set; }
    }

    public class IndexFiltred
    {
        public int? Page { get; set; }
        public AdType? AdType { get; set; }
        public string FlatCities { get; set; }
        public int? FlatRooms { get; set; }
        public string HouseCities { get; set; }
        public string LandCities { get; set; }
        public string AllCities { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo  { get; set; }
        public SortOption? SortOption { get; set; }
    }
}