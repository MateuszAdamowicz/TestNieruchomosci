using System;
using System.Collections.Generic;
using System.Linq;
using Context;
using Models.EntityModels;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.AdvertServices.AdminFilterAdvertService.Implementation
{
    public class AdminFilterAdvertService : IAdminFilterAdvertService
    {
        private readonly IGenericRepository _genericRepository;

        public AdminFilterAdvertService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdverts(string key, string worker, bool? showHidden, DateTime? dateFrom, DateTime? dateTo, IEnumerable<AdType> type)
        {
            var searchFlats = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(_genericRepository.GetSet<Flat>());
            var searchHouses = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(_genericRepository.GetSet<House>());
            var searchLands = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(_genericRepository.GetSet<Land>());

            var advertsToShow = searchFlats.Concat(searchHouses).Concat(searchLands);

            if (!String.IsNullOrEmpty(key))
            {
                advertsToShow = advertsToShow.Where(x => x.Title.Contains(key) || x.City.Contains(key) || x.Number == key);
            }

            if (!String.IsNullOrEmpty(worker))
            {
                advertsToShow = advertsToShow.Where(x =>x.Worker != null &&(x.Worker.FirstName == worker || x.Worker.LastName == worker || x.Worker.FullName.Contains(worker)));
            }

            if (showHidden == false)
            {
                advertsToShow = advertsToShow.Where(x => x.Visible);
            }
            else
            {
                advertsToShow = advertsToShow.Where(x => !x.Visible);
            }

            if (dateFrom != null)
            {
                advertsToShow = advertsToShow.Where(x => x.CreatedAt.Date >= dateFrom);
            }

            if (dateTo != null)
            {
                advertsToShow = advertsToShow.Where(x => x.CreatedAt.Date <= dateTo);
            }

            if (type != null && type.Any())
            {
                advertsToShow = advertsToShow.Where(x => type.Contains(x.AdType));
            }

            advertsToShow = advertsToShow.OrderByDescending(x => x.CreatedAt);

            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> ActiveAdverts(bool? hidden)
        {
            List<AdminAdvertToShow> flats;
            List<AdminAdvertToShow> houses;
            List<AdminAdvertToShow> lands;
            if (hidden != null && hidden == true)
            {
                flats =
                    AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(
                        _genericRepository.GetSet<Flat>().Where(x => !x.Visible));
                houses =
                    AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(
                        _genericRepository.GetSet<House>().Where(x => !x.Visible));
                lands =
                    AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(
                        _genericRepository.GetSet<Land>().Where(x => !x.Visible));
            }
            else
            {
                flats = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_genericRepository.GetSet<Flat>().Where(x => x.Visible));
                houses = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_genericRepository.GetSet<House>().Where(x => x.Visible));
                lands = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_genericRepository.GetSet<Land>().Where(x => x.Visible));
            }
            var advertsToShow = flats.Concat(houses).Concat(lands).OrderByDescending(x => x.CreatedAt);
            return advertsToShow;
        }
    }
}