using System;
using System.Collections.Generic;
using System.Data.Entity;
using Context;
using Models.EntityModels;
using Services;

namespace nieruchomości.Migrations
{
    public class IfModelChanges : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {

            var rnd = new Random();

            var seedService = new SeedService();

            context.SaveChanges();

            var flats = new List<Flat>();

            for (int i = 0; i < 20; i++)
            {
                var flat = seedService.GetFlat();
                context.Flats.Add(flat);
            }

            var houses = new List<House>();

            for (int i = 0; i < 25; i++)
            {
                var house = seedService.GetHouse();
                context.Houses.Add(house);
            }

            var lands = new List<Land>();

            for (int i = 0; i < 10; i++)
            {
                var land = seedService.GetLand();
                context.Lands.Add(land);
            }

            context.SaveChanges();

        }
    }
}