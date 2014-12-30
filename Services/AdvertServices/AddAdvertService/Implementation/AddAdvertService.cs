using System;
using System.Linq;
using AutoMapper;
using Context;
using Models.ApplicationModels;
using Models.EntityModels;
using Models.ViewModels;
using Services.PhotoService;

namespace Services.AdvertServices.AddAdvertService.Implementation
{
    public class AddAdvertService : IAddAdvertService
    {
        private readonly IApplicationContext _context;
        private readonly IPhotoService _photoService;

        public AddAdvertService(IApplicationContext context, IPhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
        }

        public Result<string> AddFlat(AdminFlat adminFlat)
        {
            var flat = Mapper.Map<Flat>(adminFlat);
            if (adminFlat.Worker != 0)
            {
                var worker = _context.Workers.FirstOrDefault(x => x.Id == adminFlat.Worker);
                flat.Worker = worker;
            }
            flat.Pictures = _photoService.AddAdvertPhotos(adminFlat.Files);
            foreach (var photo in flat.Pictures)
            {
                photo.AdType = AdType.Flat;
                photo.Flat = flat;
            }

            var result = _context.Flats.Add(flat);

            _context.SaveChanges();

            return new Result<string>(true,null,"",String.Format("{0}{1}", flat.Id*9999,"12"));
        }

        public Result<string> AddLand(AdminLand adminLand)
        {
            var land = Mapper.Map<Land>(adminLand);
            var worker = Enumerable.First(_context.Workers.Where(x => x.Id == adminLand.Worker));

            land.Worker = worker;
            land.Pictures = _photoService.AddAdvertPhotos(adminLand.Files);
            foreach (var photo in land.Pictures)
            {
                photo.AdType = AdType.Land;
                photo.Land = land;
            }

            var result = _context.Lands.Add(land);

            _context.SaveChanges();

            return new Result<string>(true, null, "", String.Format("{0}{1}", land.Id*9999,"18"));
        }

        public Result<string> AddHouse(AdminHouse adminHouse)
        {
            var house = Mapper.Map<House>(adminHouse);
            var worker = Enumerable.First(_context.Workers.Where(x => x.Id == adminHouse.Worker));

            house.Worker = worker;
            house.Pictures = _photoService.AddAdvertPhotos(adminHouse.Files);
            foreach (var photo in house.Pictures)
            {
                photo.AdType = AdType.House;
                photo.House = house;
            }

            var result = _context.Houses.Add(house);

            _context.SaveChanges();

            return new Result<string>(true, null, "", String.Format("{0}{1}",house.Id*9999,"14"));
        }
    }
}