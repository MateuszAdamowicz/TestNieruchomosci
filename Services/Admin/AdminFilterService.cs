using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Context;
using Models.ViewModels;

namespace Services.Admin
{
    public class AdminFilterService : IAdminFilterService
    {
        private readonly IApplicationContext _applicationContext;

        public AdminFilterService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdverts(string key, string worker, bool? showHidden, DateTime? dateFrom, DateTime? dateTo, IEnumerable<AdType> type)
        {
            var searchFlats = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(_applicationContext.Flats);
            var searchHouses = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(_applicationContext.Houses);
            var searchLands = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(_applicationContext.Lands);

            var advertsToShow = searchFlats.Concat(searchHouses).Concat(searchLands);

            if (!String.IsNullOrEmpty(key))
            {
                advertsToShow = advertsToShow.Where(x => x.Title.Contains(key) || x.City.Contains(key) || x.Number == key);
            }

            if (!String.IsNullOrEmpty(worker))
            {
                advertsToShow = advertsToShow.Where(x => x.Worker.FirstName == worker || x.Worker.LastName == worker);
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
                advertsToShow = advertsToShow.Where(x => x.CreatedAt >= dateFrom);
            }

            if (dateTo != null)
            {
                advertsToShow = advertsToShow.Where(x => x.CreatedAt <= dateTo);
            }

            if (type != null && type.Count() > 0)
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
                        _applicationContext.Flats.Where(x => !x.Visible && !x.Deleted));
                houses =
                    AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(
                        _applicationContext.Houses.Where(x => !x.Visible && !x.Deleted));
                lands =
                    AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(
                        _applicationContext.Lands.Where(x => !x.Visible && !x.Deleted));
            }
            else
            {
                flats = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_applicationContext.Flats.Where(x => x.Visible && !x.Deleted));
                houses = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_applicationContext.Houses.Where(x => x.Visible && !x.Deleted));
                lands = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_applicationContext.Lands.Where(x => x.Visible && !x.Deleted));
            }
            var advertsToShow = flats.Concat(houses).Concat(lands).OrderByDescending(x => x.CreatedAt);
            return advertsToShow;
        }
    }
}