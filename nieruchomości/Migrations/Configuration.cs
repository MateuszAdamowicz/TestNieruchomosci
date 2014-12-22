using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Context;
using Models.EntityModels;
using Services;

namespace nieruchomoœci.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        //protected override void Seed(ApplicationContext context)
        //{

        //    //var rnd = new Random();

        //    //var seedService = new SeedService();

        //    //var workers = new List<Worker>();

        //    //for (int i = 0; i < 10; i++)
        //    //{
        //    //    var worker = seedService.GetWorker();
        //    //    workers.Add(worker);
        //    //    context.Workers.Add(worker);
        //    //}
        //    //context.SaveChanges();

        //    //var flats = new List<Flat>();

        //    //for (int i = 0; i < 20; i++)
        //    //{
        //    //    var flat = seedService.GetFlat();
        //    //    flat.Worker = workers[rnd.Next(workers.Count)];
        //    //    context.Flats.Add(flat);
        //    //}

        //    //var houses = new List<House>();

        //    //for (int i = 0; i < 25; i++)
        //    //{
        //    //    var house = seedService.GetHouse();
        //    //    house.Worker = workers[rnd.Next(workers.Count)];
        //    //    context.Houses.Add(house);
        //    //}

        //    //var lands = new List<Land>();

        //    //for (int i = 0; i < 10; i++)
        //    //{
        //    //    var land = seedService.GetLand();
        //    //    land.Worker = workers[rnd.Next(workers.Count)];
        //    //    context.Lands.Add(land);
        //    //}

        //    //context.SaveChanges();

        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.
        //    //
        //    //    context.People.AddOrUpdate(
        //    //      p => p.FullName,
        //    //      new Person { FullName = "Andrew Peters" },
        //    //      new Person { FullName = "Brice Lambson" },
        //    //      new Person { FullName = "Rowan Miller" }
        //    //    );
        //    //
        //}
    }
}
