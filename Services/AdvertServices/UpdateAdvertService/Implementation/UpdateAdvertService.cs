using Context;
using Models.ApplicationModels;
using Models.ViewModels;
using Services.PhotoService;

namespace Services.AdvertServices.UpdateAdvertService.Implementation
{
    public class UpdateAdvertService : IUpdateAdvertService
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IPhotoService _photoService;

        public UpdateAdvertService(IApplicationContext applicationContext, IPhotoService photoService)
        {
            _applicationContext = applicationContext;
            _photoService = photoService;
        }

        public Result UpdateFlat(EditFlat editFlat, int id)
        {
            var oldFlat = _applicationContext.Flats.Find(id);
            if (oldFlat != null)
            {
                if (editFlat.ToDeleted != null)
                {
                    foreach (var photoId in editFlat.ToDeleted)
                    {
                        oldFlat.Pictures.RemoveAll(x => x.Id == photoId);
                    }
                }
                var newPhotos = _photoService.AddAdvertPhotos(editFlat.Files);
                foreach (var photo in newPhotos)
                {
                    photo.AdType = AdType.Flat;
                    photo.Flat = oldFlat;
                    oldFlat.Pictures.Add(photo);
                }
                oldFlat.Title = editFlat.Title;
                oldFlat.Area = editFlat.Area;
                oldFlat.City = editFlat.City;
                oldFlat.Description = editFlat.Description;
                oldFlat.Details = editFlat.Details;
                oldFlat.Heating = editFlat.Heating;
                oldFlat.Location = editFlat.Location;
                oldFlat.Ownership = editFlat.Ownership;
                oldFlat.Price = editFlat.Price;
                oldFlat.PricePerMeter = editFlat.PricePerMeter;
                oldFlat.Rent = editFlat.Rent;
                oldFlat.Rooms = editFlat.Rooms;
                oldFlat.Storey = editFlat.Storey;
                oldFlat.Worker = _applicationContext.Workers.Find(editFlat.Worker);
                oldFlat.ToLet = editFlat.ToLet;
                oldFlat.TechnicalCondition = editFlat.TechnicalCondition;

                _applicationContext.SaveChanges();

                return new Result(true, null, "");
            }
            return new Result(false,null,"");
        }

        public Result UpdateHouse(EditHouse editHouse, int id)
        {
            var oldHouse = _applicationContext.Houses.Find(id);
            if (oldHouse != null)
            {
                if (editHouse.ToDeleted != null)
                {
                    foreach (var photoId in editHouse.ToDeleted)
                    {
                        oldHouse.Pictures.RemoveAll(x => x.Id == photoId);
                    }
                }

                var newPhotos = _photoService.AddAdvertPhotos(editHouse.Files);
                foreach (var photo in newPhotos)
                {
                    photo.AdType = AdType.House;
                    photo.House = oldHouse;
                    oldHouse.Pictures.Add(photo);
                }

                oldHouse.Title = editHouse.Title;
                oldHouse.LandArea = editHouse.LandArea;
                oldHouse.UsableArea = editHouse.UsableArea;
                oldHouse.City = editHouse.City;
                oldHouse.Description = editHouse.Description;
                oldHouse.Details = editHouse.Details;
                oldHouse.Heating = editHouse.Heating;
                oldHouse.Location = editHouse.Location;
                oldHouse.Ownership = editHouse.Ownership;
                oldHouse.Price = editHouse.Price;
                oldHouse.PricePerMeter = editHouse.PricePerMeter;
                oldHouse.Rent = editHouse.Rent;
                oldHouse.Rooms = editHouse.Rooms;
                oldHouse.Worker = _applicationContext.Workers.Find(editHouse.Worker);
                oldHouse.ToLet = editHouse.ToLet;
                oldHouse.TechnicalCondition = editHouse.TechnicalCondition;

                _applicationContext.SaveChanges();

                return new Result(true, null, "");
            }

            return new Result(false, null, "");
        }

        public Result UpdateLand(EditLand editLand, int id)
        {
            var oldLand = _applicationContext.Lands.Find(id);
            if (oldLand != null)
            {
                if (editLand.ToDeleted != null)
                {
                    foreach (var photoId in editLand.ToDeleted)
                    {
                        oldLand.Pictures.RemoveAll(x => x.Id == photoId);
                    }
                }
                var newPhotos = _photoService.AddAdvertPhotos(editLand.Files);
                foreach (var photo in newPhotos)
                {
                    photo.AdType = AdType.Land;
                    photo.Land = oldLand;
                    oldLand.Pictures.Add(photo);
                }
                oldLand.Title = editLand.Title;
                oldLand.Area = editLand.Area;
                oldLand.City = editLand.City;
                oldLand.Description = editLand.Description;
                oldLand.Details = editLand.Details;
                oldLand.Location = editLand.Location;
                oldLand.Ownership = editLand.Ownership;
                oldLand.Price = editLand.Price;
                oldLand.Worker = _applicationContext.Workers.Find(editLand.Worker);
                
                _applicationContext.SaveChanges();

                return new Result(true, null, "");
            }
            return new Result(false, null , "");
        }
    }
}