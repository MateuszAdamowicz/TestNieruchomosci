using System.Collections.Generic;
using System.Data.Entity;
using Context;
using Models.EntityModels;
using Models.ViewModels;

namespace nieruchomości.Migrations
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var worker1 = new Worker()
            {
                FirstName = "Mateusz",
                LastName = "Adamowicz",
                Email = "madamowicz@pgs-soft.com",
                PhoneFirst = "794669564",
                PhoneSecond = "65465466"
            };

            var worker2 = new Worker()
            {
                FirstName = "Mikołaj",
                LastName = "Koren",
                Email = "mkoren@pgs-soft.com",
            };

            var flat1= new Flat()
            {
                City = "Szczecin",
                Heating = "Gazowe"
            };
            var flat2 = new Flat()
            {
                City = "Wrocław",
                Heating = "Piec"
            };

            var flat3 = new Flat()
            {
                City = "Jelenie Góra",
                Location = "Zaborze III",
                Area = "62 m2",
                Storey = "IV piętro",
                TechnicalCondition = "do zamieszkania",
                Rooms = "3 pokoje",
                Heating = "sieciowe",
                Rent = "500zł",
                Ownership = "spółdzielcze wł z KW",
                Price = "199 000zł",
                Description =
                    "Prezentuję Państwu do sprzedaży trzypokojowe mieszkanie na osiedlu Zabobrze w jego nowszej części w ocieplonym bloku czteropiętrowym. Lokal zadbany, słoneczny z balkonu rozpościera się ładny widok na panoramę pogórza. Sprzedaż wraz z meblami i sprzętem AGD.",
                Details =
                    "Opłaty zawarte w czynszu : inne , administracyjne , fundusz remontowy , ogrzewanie , woda ciepła , Dodatkowe powierzchnie : Piwnica , Pośrednik odpowiedzialny : 4917 , NOTA PRAWNA : : Wszystkie szczegóły ofert zestawiono na podstawie wypowiedzi lub dokumentacji przedstawionej przez właścicieli nieruchomości. Jednocześnie nie bierzemy odpowiedzialności za ich prawidłowość, kompletność i aktualność. Oferty nie stanowią oferty handlowej w rozumieniu kodeksu cywilnego i nie są wiążące.",
                Title = "Trzypokojowe przy Kiepury",
                Pictures = new List<Photo>()
            };


            

            var house1 = new House()
            {
                City = "Szczecin",
                Heating = "Gazowe"
            };
            var house2 = new House()
            {
                City = "Wrocław",
                Heating = "Piec"
            };

            var land1 = new Land()
            {
                City="Szczecin",
                Area="100"
            };
            var land2 = new Land()
            {
                City = "Wrocław",
                Area = "110"
            };
            
            context.Workers.Add(worker1);
            context.Workers.Add(worker2);
            context.Houses.Add(house1);
            context.Houses.Add(house2);
            flat3.Worker = worker1;
            for (int i = 0; i < 13; i++)
            {
                flat3.Pictures.Add(new Photo()
                {
                    AdType = AdType.Flat,
                    Link = "728803_1.jpg"
                });
            }
            context.Flats.Add(flat3);
            context.Flats.Add(flat1);
            context.Flats.Add(flat2);
            context.Lands.Add(land1);
            context.Lands.Add(land2);
            context.SaveChanges();
        }
    }
}