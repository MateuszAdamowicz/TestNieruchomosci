using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models.EntityModels;
using Models.ViewModels;
using Services.GenericRepository;
using Services.SearchService;

namespace Services.AdvertServices.ChangeAdvertVisability.Implementation
{
    public class ChangeAdvertVisibility : IChangeAdvertVisibility
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISearchService _searchService;

        public ChangeAdvertVisibility(IGenericRepository genericRepository, ISearchService searchService)
        {
            _genericRepository = genericRepository;
            _searchService = searchService;
        }

        public bool HideAdverts(IEnumerable<string> numbers)
        {
            var visibled = false;
            if (numbers != null)
            {
                foreach (var number in numbers)
                {
                    var parsedSearch = _searchService.ParseKey(number);
                    if (parsedSearch.Id != 0)
                    {
                        if (parsedSearch.AdType == AdType.Flat)
                        {
                            var advert = _genericRepository.GetSet<Flat>().FirstOrDefault(x => x.Id == parsedSearch.Id);
                            if (advert != null)
                            {
                                advert.Visible = !advert.Visible;
                                visibled = advert.Visible;
                            }
                        }
                        else if (parsedSearch.AdType == AdType.House)
                        {
                            var advert = _genericRepository.GetSet<House>().FirstOrDefault(x => x.Id == parsedSearch.Id);
                            if (advert != null)
                            {
                                advert.Visible = !advert.Visible;
                                visibled = advert.Visible;
                            }
                        }
                        else
                        {
                            var advert = _genericRepository.GetSet<Land>().FirstOrDefault(x => x.Id == parsedSearch.Id);
                            if (advert != null)
                            {
                                advert.Visible = !advert.Visible;
                                visibled = advert.Visible;
                            }
                        }
                    }
                }
                _genericRepository.SaveChanges();
            }
            return visibled;
        }

        public void DeleteAdverts(IEnumerable<string> numbers)
        {
            if (numbers != null)
            {
                foreach (var number in numbers)
                {
                    var parsedSearch = _searchService.ParseKey(number);

                    if (parsedSearch.Id != 0)
                    {
                        if (parsedSearch.AdType == AdType.Flat)
                        {
                            var flat = _genericRepository.GetSet<Flat>().FirstOrDefault(x => x.Id == parsedSearch.Id);
                            if (flat != null) flat.Deleted = true;
                        }
                        else if (parsedSearch.AdType == AdType.House)
                        {
                            var house = _genericRepository.GetSet<House>().FirstOrDefault(x => x.Id == parsedSearch.Id);
                            if (house != null) house.Deleted = true;
                        }
                        else
                        {
                            var land = _genericRepository.GetSet<Land>().FirstOrDefault(x => x.Id == parsedSearch.Id);
                            if (land != null) land.Deleted = true;
                        }

                    }
                }
                _genericRepository.SaveChanges();
            }
        }
    }
}