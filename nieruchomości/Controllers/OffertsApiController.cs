using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Context;
using Models.EntityModels;
using Models.ViewModels;
using Services.AdvertServices.NewestAdvertService;
using Services.GenericRepository;

namespace nieruchomości.Controllers
{
    public class OffertsApiController : ApiController
    {
        private readonly IApplicationContext _context;
        private readonly INewestAdvertService _newestAdvertService;
        private readonly IGenericRepository _genericRepository;

        public OffertsApiController(IApplicationContext context, INewestAdvertService newestAdvertService, IGenericRepository genericRepository)
        {
            _context = context;
            _newestAdvertService = newestAdvertService;
            _genericRepository = genericRepository;
        }


        public IEnumerable<NewestAdvert> GetNewest()
        {
            return _newestAdvertService.GetNewest(4);
        }

        public IEnumerable<ShowListHouse> GetHouses()
        {
            List<House> houseData = _genericRepository.GetSet<House>().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).ToList();
            List<ShowListHouse> listHouse = AutoMapper.Mapper.Map<List<ShowListHouse>>(houseData);
            return listHouse;
        }

        public IEnumerable<ShowListFlat> GetFlats()
        {
            List<Flat> flatData = _genericRepository.GetSet<Flat>().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).ToList();
            List<ShowListFlat> listFlat= AutoMapper.Mapper.Map<List<ShowListFlat>>(flatData);
            return listFlat;
        }

        public IEnumerable<ShowListLand> GetLands()
        {
            List<Land> landData = _genericRepository.GetSet<Land>().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).ToList();
            List<ShowListLand> listLand = AutoMapper.Mapper.Map<List<ShowListLand>>(landData);
            return listLand;
        }

        public House Put(House user)
        {
            return user;
        }

        public House Post(House user)
        {
            return null;
        }

    }
}
