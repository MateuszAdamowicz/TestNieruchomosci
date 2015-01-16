using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models.EntityModels;
using Models.ViewModels;
using Services.AdvertServices.SortAdvertService.Implementation;
using Services.GenericRepository;

namespace Services.AdvertServices.GetFiltredAdvertsService.Implementation
{
    public class GetFiltredAdvertsService : IGetFiltredAdvertsService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISortAdvertService _sortAdvertService;

        public GetFiltredAdvertsService(IGenericRepository genericRepository, ISortAdvertService sortAdvertService)
        {
            _genericRepository = genericRepository;
            _sortAdvertService = sortAdvertService;
        }

        public List<ShowAdvertList> GetAdverts(AdType? adType, string flatCities, int? flatRooms, string houseCities,
            string landCities, string allCities, int? priceFrom, int? priceTo, SortOption? sortOption)
        {

            var offersToFilter = new List<ShowAdvertList>();

            if (adType == null)
            {
                var flats =
                    _genericRepository.GetSet<Flat>().Where(x => x.Price >= priceFrom && x.Price <= priceTo && (String.IsNullOrEmpty(allCities) || x.City == allCities)).ToList();
                var houses =
                    _genericRepository.GetSet<House>().Where(x => x.Price >= priceFrom && x.Price <= priceTo && (String.IsNullOrEmpty(allCities) || x.City == allCities)).ToList();
                var lands =
                    _genericRepository.GetSet<Land>().Where(x => x.Price >= priceFrom && x.Price <= priceTo && (String.IsNullOrEmpty(allCities) || x.City == allCities)).ToList();

                var flatList = Mapper.Map<IEnumerable<ShowAdvertList>>(flats);
                var houseList = Mapper.Map<IEnumerable<ShowAdvertList>>(houses);
                var landList = Mapper.Map<IEnumerable<ShowAdvertList>>(lands);

                offersToFilter = flatList.Concat(houseList.Concat(landList)).ToList();

            }
            else
            {
                if (adType == AdType.Flat)
                {
                    var flats =
                         _genericRepository.GetSet<Flat>().Where(x => x.Price >= priceFrom && x.Price <= priceTo && (String.IsNullOrEmpty(flatCities) || x.City == flatCities));


                    if (flatRooms != null)
                    {
                        if (flatRooms == 9)
                        {
                            flats = flats.Where(x => x.Rooms >= 9);
                        }
                        else
                        {
                            flats = flats.Where(x => x.Rooms == flatRooms);
                        }
                    }

                    offersToFilter = Mapper.Map<IEnumerable<ShowAdvertList>>(flats).ToList();

                    
                }
                else if (adType == AdType.House)
                {
                    var houses =
                        _genericRepository.GetSet<House>()
                            .Where(x => x.Price >= priceFrom && x.Price <= priceTo && (String.IsNullOrEmpty(houseCities) || x.City == houseCities))
                            .ToList();
                    offersToFilter = Mapper.Map<IEnumerable<ShowAdvertList>>(houses).ToList();
                }
                else
                {
                    var lands =
                         _genericRepository.GetSet<Land>().Where(x => x.Price >= priceFrom && x.Price <= priceTo && (String.IsNullOrEmpty(landCities) || x.City == landCities)).ToList();
                    offersToFilter = Mapper.Map<IEnumerable<ShowAdvertList>>(lands).ToList();
                }
            }
            offersToFilter = _sortAdvertService.SortAdverts(offersToFilter.ToList(), sortOption);

            return offersToFilter;
        }
    }
}