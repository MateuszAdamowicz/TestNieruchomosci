using System.Collections.Generic;
using System.Linq;
using Models.EntityModels;

namespace Services.Admin
{
    public interface IRepository
    {
        IQueryable<Worker> Workers();
        IQueryable<Flat> Flats();
        IQueryable<House> Houses();
        IQueryable<Land> Lands();
        IQueryable<Offer> Offers();
        IQueryable<Mail> Mails();
        IQueryable<Statistics> Statisticses();
        void SaveChanges();
    }
}