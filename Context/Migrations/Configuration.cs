using System.Security.Cryptography.X509Certificates;
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
            ContextKey = "Context.ApplicationContext";
        }

        protected override void Seed(Context.ApplicationContext context)
        {
            var CostProp1 = new CostProperty()
            {
                Name = "Podatek od czynnoœci cywilnoprawnych",
                Value = 0.02,
                Type = PropertyType.VatClat
            };

            var CostProp2 = new CostProperty()
            {
                Name = "VAT od taksy notarialnej",
                Value = 22,
                Type = PropertyType.VatNotary
            };

            var CostProp3 = new CostProperty()
            {
                Name = "Za³o¿enie KW",
                Value = 40,
                Type = PropertyType.Mr
            };

            var CostProp4 = new CostProperty()
            {
                Name = "Prowizja agencji",
                Value = 0,
                Type = PropertyType.AgencyCommissionPercent
            };

            var CostProp5 = new CostProperty()
            {
                Name = "VAT od prowizji agencji",
                Value = 0.23,
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
                Max = 0
            };


            var ClatProp2 = new Clat
            {
                From = 3000,
                To = 10000,
                Percent = 3,
                Max = 0
            };

            var ClatProp3 = new Clat
            {
                From = 10000,
                To = 30000,
                Percent = 2,
                Max = 0
            };

            var ClatProp4 = new Clat
            {
                From = 30000,
                To = 60000,
                Percent = 1,
                Max = 0
            };

            var ClatProp5 = new Clat
            {
                From = 60000,
                To = 1000000,
                Percent = 0.4,
                Max = 0
            };

            var ClatProp6 = new Clat
            {
                From = 1000000,
                To = 2000000,
                Percent = 0.2,
                Max = 0
            };

            var ClatProp7 = new Clat
            {
                From = 2000000,
                To = Double.MaxValue,
                Percent = 0.25,
                Max = 10000
            };

            context.Clats.AddOrUpdate(x => x.To, ClatProp1);
            context.Clats.AddOrUpdate(x => x.To, ClatProp2);
            context.Clats.AddOrUpdate(x => x.To, ClatProp3);
            context.Clats.AddOrUpdate(x => x.To, ClatProp4);
            context.Clats.AddOrUpdate(x => x.To, ClatProp5);
            context.Clats.AddOrUpdate(x => x.To, ClatProp6);
            context.Clats.AddOrUpdate(x => x.To, ClatProp7);

            context.SaveChanges();
        }
    }
}
