using System.Collections.Generic;

namespace Models.ViewModels
{
    public class IndexFilterOptions
    {
        public List<SelectOption> AdTypes { get; set; }
        public List<SelectOption> ToLet { get; set; }
        public List<SelectOption> FlatCities { get; set; }
        public List<SelectOption> HouseCities { get; set; }
        public List<SelectOption> LandCities { get; set; }
        public List<SelectOption> AllCities { get; set; }
        public List<SelectOption> Rooms { get; set; }
        public List<SelectOption> SortOptions { get; set; }
    }
}