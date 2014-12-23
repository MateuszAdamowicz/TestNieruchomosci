using System.Data.Entity;
using Models.EntityModels;

namespace Context
{
    public interface IApplicationContext
    {
        IDbSet<Worker> Workers { get; set; }
        IDbSet<Flat> Flats { get; set; }
        IDbSet<House> Houses { get; set; }
        IDbSet<Land> Lands { get; set; }
        IDbSet<Photo> Photos { get; set; }
        IDbSet<Offer> Offers { get; set; }
        IDbSet<Mail> Mails { get; set; }
        IDbSet<Statistics> Statisticses { get; set; }
        IDbSet<Clat> Clats { get; set; }
        IDbSet<CostProperty> CostProperties { get; set; }
        void SaveChanges();
    }
}