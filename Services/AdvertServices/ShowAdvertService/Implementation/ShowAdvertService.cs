using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using AutoMapper;
using Context;
using Models.ApplicationModels;
using Models.EntityModels;
using Models.ViewModels;
using Services.AdvertServices.GetAdvertService.Implementation;
using Services.AdvertServices.GetNextPreviousService;
using Services.GenericRepository;
using TYPEATTR = System.Runtime.InteropServices.ComTypes.TYPEATTR;

namespace Services.AdvertServices.ShowAdvertService.Implementation
{
    public class ShowAdvertService : IShowAdvertService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IGenericRepository _genericRepository;
        private readonly IGetAdvertService _getAdvertService;
        private readonly IGetNextPreviousService _getNextPreviousService;

        public ShowAdvertService(ApplicationContext applicationContext, IGenericRepository genericRepository, IGetAdvertService getAdvertService, IGetNextPreviousService getNextPreviousService)
        {
            _applicationContext = applicationContext;
            _genericRepository = genericRepository;
            _getAdvertService = getAdvertService;
            _getNextPreviousService = getNextPreviousService;
        }


        public Result<ShowAdvert> GetAdvert(AdType adType, int id, bool admin)
        {
            var showAdvert = new ShowAdvert { AdType = adType };

            if (adType == AdType.Flat)
            {
                var flat = _getAdvertService.GetAdvert<Flat, ShowFlat>(id, admin);

                if (flat == null)
                {
                    return new Result<ShowAdvert>(false, null, "", null);
                }

                var neighbours = _getNextPreviousService.GetNeighbours<Flat, ShowFlat>(id);
                if (neighbours.Previous != null)
                {
                    flat.Previous = neighbours.Previous.Number;
                }
                if (neighbours.Next != null)
                {
                    flat.Next = neighbours.Next.Number;
                }
                
                showAdvert.Flat = flat;
            }
            else if (adType == AdType.House)
            {
                var house = _getAdvertService.GetAdvert<House, ShowHouse>(id, admin);
                if (house == null)
                {
                    return new Result<ShowAdvert>(false, null, "", null);
                }

                var neighbours = _getNextPreviousService.GetNeighbours<House, ShowHouse>(id);
                if (neighbours.Previous != null)
                {
                    house.Previous = neighbours.Previous.Number;
                }
                if (neighbours.Next != null)
                {
                    house.Next = neighbours.Next.Number;
                }
                showAdvert.House = house;
            }
            else if (adType == AdType.Land)
            {
                var land = _getAdvertService.GetAdvert<Land, ShowLand>(id, admin);
                if (land == null)
                {
                    return new Result<ShowAdvert>(false, null, "", null);
                }

                var neighbours = _getNextPreviousService.GetNeighbours<Land, ShowLand>(id);
                if (neighbours.Previous != null)
                {
                    land.Previous = neighbours.Previous.Number;
                }
                if (neighbours.Next != null)
                {
                    land.Next = neighbours.Next.Number;
                }
                showAdvert.Land = land;
            }

            return new Result<ShowAdvert>(true, null, "", showAdvert);
        } 
    }
}