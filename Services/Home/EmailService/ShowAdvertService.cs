using System.Linq;
using Context;
using Models.ApplicationModels;
using Models.ViewModels;

namespace Services.Home.EmailService
{
    public class ShowAdvertService : IShowAdvertService
    {
        private readonly ApplicationContext _applicationContext;

        public ShowAdvertService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Result<ShowAdvert> GetAdvert(AdType adType, int id)
        {
            var showAdvert = new ShowAdvert { AdType = adType };

            if (adType == AdType.Flat)
            {
                var flat = Enumerable.FirstOrDefault(_applicationContext.Flats.Where(x => x.Id == id));
                if (flat == null)
                {
                    return new Result<ShowAdvert>(false, null, "", null);
                }
                var showFlat = AutoMapper.Mapper.Map<ShowFlat>(flat);
                showAdvert.Flat = showFlat;
            }
            else if (adType == AdType.House)
            {
                var house = Enumerable.FirstOrDefault(_applicationContext.Houses.Where(x => x.Id == id));
                if (house == null)
                {
                    return new Result<ShowAdvert>(false, null, "", null);
                }
                var showHouse = AutoMapper.Mapper.Map<ShowHouse>(house);
                showAdvert.House = showHouse;
            }
            else if (adType == AdType.Land)
            {
                var land = Enumerable.FirstOrDefault(_applicationContext.Lands.Where(x => x.Id == id));
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