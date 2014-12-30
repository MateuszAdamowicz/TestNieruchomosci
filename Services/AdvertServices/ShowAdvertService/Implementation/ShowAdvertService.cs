using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Context;
using Models.ApplicationModels;
using Models.EntityModels;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.AdvertServices.ShowAdvertService.Implementation
{
    public class ShowAdvertService : IShowAdvertService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IGenericRepository _genericRepository;

        public ShowAdvertService(ApplicationContext applicationContext, IGenericRepository genericRepository)
        {
            _applicationContext = applicationContext;
            _genericRepository = genericRepository;
        }

        public Result<ShowAdvert> GetAdvert(AdType adType, int id, bool admin)
        {
            var showAdvert = new ShowAdvert { AdType = adType };

            if (adType == AdType.Flat)
            {
                var flats = _genericRepository.GetSet<Flat>().Where(x => x.Id == id);
                if (!admin)
                {
                    flats = flats.Where(x => x.Visible);
                }
                var flat = flats.FirstOrDefault();
                if (flat == null)
                {
                    return new Result<ShowAdvert>(false, null, "", null);
                }
                var showFlat = AutoMapper.Mapper.Map<ShowFlat>(flat);
                showAdvert.Flat = showFlat;
            }
            else if (adType == AdType.House)
            {
                var houses = _genericRepository.GetSet<House>().Where(x => x.Id == id);
                if (!admin)
                {
                    houses = houses.Where(x => x.Visible);
                }
                var house = houses.FirstOrDefault();
                if (house == null)
                {
                    return new Result<ShowAdvert>(false, null, "", null);
                }
                var showHouse = AutoMapper.Mapper.Map<ShowHouse>(house);
                showAdvert.House = showHouse;
            }
            else if (adType == AdType.Land)
            {
                var lands = _genericRepository.GetSet<Land>().Where(x => x.Id == id);
                if (!admin)
                {
                    lands = lands.Where(x => x.Visible);
                }
                var land = lands.FirstOrDefault();
                if (land == null)
                {
                    return new Result<ShowAdvert>(false, null, "", null);
                }
                var showLand = AutoMapper.Mapper.Map<ShowLand>(land);
                showAdvert.Land = showLand;
            }

            return new Result<ShowAdvert>(true, null, "", showAdvert);
        } 
    }
}