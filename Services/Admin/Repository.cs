using System.Collections.Generic;
using System.Linq;
using Context;
using Models.EntityModels;

namespace Services.Admin
{
    public class Repository : IRepository
    {
        private readonly IApplicationContext _applicationContext;

        public Repository(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IQueryable<Worker> Workers()
        {
            return _applicationContext.Workers.Where(x => !x.Deleted);
        }

        public IQueryable<Flat> Flats()
        {
            return _applicationContext.Flats.Where(x => !x.Deleted);
        }

        public IQueryable<House> Houses()
        {
            return _applicationContext.Houses.Where(x => !x.Deleted);
        }

        public IQueryable<Land> Lands()
        {
            return _applicationContext.Lands.Where(x => !x.Deleted);
        }

        public IQueryable<Offer> Offers()
        {
            return _applicationContext.Offers.Where(x => !x.Deleted);
        }

        public IQueryable<Mail> Mails()
        {
            return _applicationContext.Mails.Where(x => !x.Deleted);
        }

        public IQueryable<Statistics> Statisticses()
        {
            return _applicationContext.Statisticses;
        } 

        public void SaveChanges()
        {
            _applicationContext.SaveChanges();
        }
    }
}