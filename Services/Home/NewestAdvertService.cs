using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Context;
using Models.ViewModels;

namespace Services.Home
{
    public class NewestAdvertService : INewestAdvertService
    {
        private readonly IApplicationContext _applicationContext;

        public NewestAdvertService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<NewestAdvert> GetNewest(int count)
        {
            var flats = _applicationContext.Flats.OrderByDescending(x => x.CreatedAt).Take(count).ToList();
            var houses = _applicationContext.Houses.OrderByDescending(x => x.CreatedAt).Take(count).ToList();
            var lands = _applicationContext.Lands.OrderByDescending(x => x.CreatedAt).Take(count).ToList();

            var flatsvm = Mapper.Map <IEnumerable<NewestAdvert>>(flats);
            var housesvm = Mapper.Map <IEnumerable<NewestAdvert>>(houses);
            var landsvm = Mapper.Map <IEnumerable<NewestAdvert>>(lands);

            var all = (flatsvm.Concat(housesvm).Concat(landsvm)).OrderByDescending(x => x.CreatedAt);

            var result = all.Take(count);

            return result;
        }
    }
}