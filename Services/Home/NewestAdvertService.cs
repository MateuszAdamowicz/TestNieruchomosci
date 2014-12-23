using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Context;
using Models.ViewModels;
using Services.Admin;

namespace Services.Home
{
    public class NewestAdvertService : INewestAdvertService
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IRepository _repository;

        public NewestAdvertService(IApplicationContext applicationContext, IRepository repository)
        {
            _applicationContext = applicationContext;
            _repository = repository;
        }

        public IEnumerable<NewestAdvert> GetNewest(int count)
        {
            var flats = _repository.Flats().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).Take(count).ToList();
            var houses = _repository.Houses().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).Take(count).ToList();
            var lands = _repository.Lands().Where(x => x.Visible).OrderByDescending(x => x.CreatedAt).Take(count).ToList();

            var flatsvm = Mapper.Map <IEnumerable<NewestAdvert>>(flats);
            var housesvm = Mapper.Map <IEnumerable<NewestAdvert>>(houses);
            var landsvm = Mapper.Map <IEnumerable<NewestAdvert>>(lands);

            var all = (flatsvm.Concat(housesvm).Concat(landsvm)).OrderByDescending(x => x.CreatedAt);

            var result = all.Take(count);

            return result;
        }
    }
}