using System.Linq;
using AutoMapper;
using Models.EntityModels;
using Services.GenericRepository;

namespace Services.AdvertServices.GetAdvertService.Implementation
{
    public class GetAdvertService : IGetAdvertService
    {
        private readonly IGenericRepository _genericRepository;

        public GetAdvertService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public TT GetAdvert<T, TT>(int id, bool admin)
            where T : Ad
            where TT : class
        {
            var adverts = _genericRepository.GetSet<T>().Where(x => x.Id == id);
            if (!admin)
            {
                adverts = adverts.Where(x => x.Visible);
            }
            var advert = adverts.FirstOrDefault();
            if (advert == null)
            {
                return null;
            }
            var showAdvert = Mapper.Map<TT>(advert);

            return showAdvert;
        } 
    }
}