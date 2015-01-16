using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using Models.EntityModels;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.AdvertCitiesService.Implementation
{
    public class AdvertCitiesService : IAdvertCitiesService
    {
        private readonly IGenericRepository _genericRepository;

        public AdvertCitiesService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<SelectOption> GetCities<T>() where T : Ad
        {
            var set = _genericRepository.GetSet<T>().Where(x => x.Visible).Select(x => x.City).GroupBy(x => x).Select( x => x.Key).ToList();
            var options = set.Select(city => new SelectOption(String.Format("Miejscowość: {0}",city),city)).ToList();
            options.Insert(0, new SelectOption("Miejscowość: Wszystkie", ""));
            return options;
        }

        public List<CityCount> GetCitiesWithRepeats(int count)
        {
            var flatCities = _genericRepository.GetSet<Flat>().Where(x => x.Visible).Select(x => x.City);
            var houseCities = _genericRepository.GetSet<House>().Where(x => x.Visible).Select(x => x.City);
            var landCities = _genericRepository.GetSet<Land>().Where(x => x.Visible).Select(x => x.City);

            var cities = flatCities.Concat(houseCities.Concat(landCities));

            var result =
                cities.GroupBy(x => x).Select(x => new CityCount() {CityName = x.Key, Count = x.Count()}).Take(count).ToList();

            return result;
        } 
    }
}