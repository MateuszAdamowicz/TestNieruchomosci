using System.Collections.Generic;
using Models.EntityModels;

namespace Context.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<Context.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Context.ApplicationContext";
        }
        protected override void Seed(Context.ApplicationContext context)
        {
            var CostProp1 = new CostProperty()
            {
                Name = "Podatek od czynnoœci cywilnoprawnych",
                Value = 2,
                Type = PropertyType.VatClat
            };

            var CostProp2 = new CostProperty()
            {
                Name = "VAT od taksy notarialnej",
                Value = 23,
                Type = PropertyType.VatNotary
            };

            var CostProp3 = new CostProperty()
            {
                Name = "Za³o¿enie KW",
                Value = 200,
                Type = PropertyType.Mr
            };

            var CostProp4 = new CostProperty()
            {
                Name = "Prowizja agencji",
                Value = 2,
                Type = PropertyType.AgencyCommissionPercent
            };

            var CostProp5 = new CostProperty()
            {
                Name = "VAT od prowizji agencji",
                Value = 23,
                Type = PropertyType.VatAgencyCommission
            };


            var CostProp6 = new CostProperty()
            {
                Name = "Wypisy aktu (strona)",
                Value = 7.3,
                Type = PropertyType.ActPagePrice
            };


            var CostProp7 = new CostProperty()
            {
                Name = "Op³ata s¹dowa",
                Value = 200,
                Type = PropertyType.CourtFee
            };

            context.CostProperties.AddOrUpdate(x => x.Type, CostProp1);
            context.CostProperties.AddOrUpdate(x => x.Type, CostProp2);
            context.CostProperties.AddOrUpdate(x => x.Type, CostProp3);
            context.CostProperties.AddOrUpdate(x => x.Type, CostProp4);
            context.CostProperties.AddOrUpdate(x => x.Type, CostProp5);
            context.CostProperties.AddOrUpdate(x => x.Type, CostProp6);
            context.CostProperties.AddOrUpdate(x => x.Type, CostProp7);

            var ClatProp1 = new Clat
            {
                From = 0,
                To = 3000,
                Percent = 0,
                Max = 0,
                Price = 0
            };

            var ClatProp2 = new Clat
            {
                From = 3000,
                To = 10000,
                Percent = 3,
                Max = 0,
                Price = 100
            };

            var ClatProp3 = new Clat
            {
                From = 10000,
                To = 30000,
                Percent = 2,
                Max = 0,
                Price = 310
            };

            var ClatProp4 = new Clat
            {
                From = 30000,
                To = 60000,
                Percent = 1,
                Max = 0,
                Price = 710
            };


            var ClatProp5 = new Clat
            {
                From = 60000,
                To = 1000000,
                Percent = 0.4,
                Max = 0,
                Price = 1010
            };

            var ClatProp6 = new Clat
            {
                From = 1000000,
                To = 2000000,
                Percent = 0.2,
                Max = 0,
                Price = 4770
            };

            var ClatProp7 = new Clat
            {
                From = 2000000,
                To = Double.MaxValue,
                Percent = 0.25,
                Max = 10000,
                Price = 0
            };

            context.Clats.AddOrUpdate(x => x.To, ClatProp1);
            context.Clats.AddOrUpdate(x => x.To, ClatProp2);
            context.Clats.AddOrUpdate(x => x.To, ClatProp3);
            context.Clats.AddOrUpdate(x => x.To, ClatProp4);
            context.Clats.AddOrUpdate(x => x.To, ClatProp5);
            context.Clats.AddOrUpdate(x => x.To, ClatProp6);
            context.Clats.AddOrUpdate(x => x.To, ClatProp7);

            context.SaveChanges();


            //var seedService = new SeedService();

            //var workers = new List<Worker>();
            //for (int i = 0; i < 20; i++)
            //{
            //    workers.Add(seedService.GetWorker());
            //}

            //var flats = new List<Flat>();
            //for (int i = 0; i < 40; i++)
            //{
            //    var flat = seedService.GetFlat();
            //    flat.Worker = workers[i % 20];
            //    flats.Add(flat);
            //}

            //var houses = new List<House>();
            //for (int i = 0; i < 40; i++)
            //{
            //    var house = seedService.GetHouse();
            //    house.Worker = workers[i % 20];
            //    houses.Add(house);
            //}

            //var lands = new List<Land>();
            //for (int i = 0; i < 40; i++)
            //{
            //    var land = seedService.GetLand();
            //    land.Worker = workers[i % 20];
            //    lands.Add(land);
            //}

            //for (int i = 0; i < 40; i++)
            //{
            //    context.Lands.Add(lands[i]);
            //    context.Flats.Add(flats[i]);
            //    context.Houses.Add(houses[i]);
            //}

            //context.SaveChanges();
        }
    }
}
