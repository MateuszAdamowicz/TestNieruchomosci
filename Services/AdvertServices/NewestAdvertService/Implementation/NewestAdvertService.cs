using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models.EntityModels;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.AdvertServices.NewestAdvertService.Implementation
{
    public class NewestAdvertService : INewestAdvertService
    {
        private readonly IGenericRepository _genericRepository;

        public NewestAdvertService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IEnumerable<NewestAdvert> GetNewest(int count)
        {
            var flats = _genericRepository.GetSet<Flat>().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).Take(count).ToList();
            var houses = _genericRepository.GetSet<House>().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).Take(count).ToList();
            var lands = _genericRepository.GetSet<Land>().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).Take(count).ToList();

            var flatsvm = Mapper.Map <IEnumerable<NewestAdvert>>(flats);
            var housesvm = Mapper.Map <IEnumerable<NewestAdvert>>(houses);
            var landsvm = Mapper.Map <IEnumerable<NewestAdvert>>(lands);

            var all = (flatsvm.Concat(housesvm).Concat(landsvm)).OrderByDescending(x => x.CreatedAt);

            var result = all.Take(count);

            return result;
        }
    }
}