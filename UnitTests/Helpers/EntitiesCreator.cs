using System;
using Models.EntityModels;

namespace UnitTests.Helpers
{
    public class EntitiesCreator
    {
        public static Flat GetFlat()
        {
            var flat = new Flat
            {
                Id = 1,
                CreatedAt = new DateTime(2015, 1, 1),
                Deleted = false,
                Title = "title",
                Description = "description",
                Details = "details",
                City = "city",
                Price = 1,
                Visible = true,
                Pictures = null,
                Counter = 1,
                Location = "location",
                Area = 10,
                Storey = 1,
                TechnicalCondition = "technicalCondition",
                Rooms = 1,
                Heating = "heating",
                Rent = "rent",
                Ownership = "ownership",
                PricePerMeter = "pricePerMeter",
                ToLet = true
            };

            return flat;
        }

        public static House GetHouse()
        {
            var house = new House()
            {
                Id = 2,
                CreatedAt = new DateTime(2015, 1, 1),
                Deleted = false,
                Title = "title",
                Description = "description",
                City = "city",
                Counter = 1,
                Details = "details",
                Heating = "heating",
                LandArea = 20,
                Location = "location",
                Ownership = "ownership",
                Pictures = null,
                Price = 1,
                PricePerMeter = "pricePerMeter",
                Rent = "rent",
                Rooms = 1,
                TechnicalCondition = "technicalCondition",
                ToLet = true,
                UsableArea = 30,
                Visible = true,
                
            };

            return house;
        }

        public static Land GetLand()
        {
            var land = new Land
            {
                Price = 1,
                CreatedAt = new DateTime(2015, 1, 1),
                Deleted = false,
                Description = "description",
                Title = "title",
                Id = 3,
                City = "city",
                Counter = 1,
                Details = "details",
                Location = "location",
                Ownership = "ownership",
                Pictures = null,
                Visible = true,
                Area = 40
            };
            return land;
        }
    }
}