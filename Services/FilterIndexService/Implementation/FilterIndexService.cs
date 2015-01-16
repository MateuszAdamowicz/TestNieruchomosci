using System;
using System.Collections.Generic;
using System.Linq;
using Models.EntityModels;
using Models.ViewModels;
using Services.AdvertCitiesService.Implementation;

namespace Services.FilterIndexService.Implementation
{
    public interface IFilterIndexService
    {
        IndexFilterOptions GetOptions();
    }

    public class FilterIndexService : IFilterIndexService
    {
        private readonly IAdvertCitiesService _advertCitiesService;

        public FilterIndexService(IAdvertCitiesService advertCitiesService)
        {
            _advertCitiesService = advertCitiesService;
        }


        public IndexFilterOptions GetOptions()
        {
            var offerType = new List<SelectOption>();
            offerType.Add(new SelectOption("Nieruchomość: Wszystkie",""));
            offerType.Add(new SelectOption("Nieruchomość: Sprzedaż","false"));
            offerType.Add(new SelectOption("Nieruchomość: Wynajem", "true"));

            var adType = new List<SelectOption>();
            adType.Add(new SelectOption("Typ oferty: Wszystkie",""));
            adType.Add(new SelectOption("Typ oferty: Mieszkanie","Flat"));
            adType.Add(new SelectOption("Typ oferty: Dom","House"));
            adType.Add(new SelectOption("Typ oferty: Działka","Land"));

            var flatCities = _advertCitiesService.GetCities<Flat>();
            var houseCities = _advertCitiesService.GetCities<House>();
            var landCities = _advertCitiesService.GetCities<Land>();
            var allCities =
                flatCities.Concat(houseCities.Concat(landCities))
                    .GroupBy(x => x.Text)
                    .Select(x => new SelectOption(x.Key, x.Key.Replace("Miejscowość: ",""))).ToList();

            allCities[0].Value = "";
            var rooms = new List<SelectOption>();
            rooms.Add(new SelectOption("Liczba pokoi: Wszystkie", ""));
            for (int i = 0; i <= 9; i++)
            {
                rooms.Add(new SelectOption(String.Format("Liczba pokoi: {0}",i),i.ToString()));
            }


            var sortOptions = new List<SelectOption>();
            sortOptions.Add(new SelectOption("Sortuj po: dacie malejąco", "DateDesc"));
            sortOptions.Add(new SelectOption("Sortuj po: dacie rosnąco", "DateAsc"));
            sortOptions.Add(new SelectOption("Sortuj po: miejscowości malejąco", "CityDesc"));
            sortOptions.Add(new SelectOption("Sortuj po: miejscowości rosnąco", "CityAsc"));
            sortOptions.Add(new SelectOption("Sortuj po: cenie malejąco", "PriceDesc"));
            sortOptions.Add(new SelectOption("Sortuj po: cenie rosnąco", "PriceAsc"));

            var indexFilterOptions = new IndexFilterOptions()
            {
                AdTypes = adType,
                FlatCities = flatCities,
                HouseCities = houseCities,
                LandCities = landCities,
                AllCities = allCities,
                Rooms = rooms,
                ToLet = offerType,
                SortOptions = sortOptions
            };

            return indexFilterOptions;
        }
    }
}