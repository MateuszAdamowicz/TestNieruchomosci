using System;
using System.Linq;
using Context;
using Models.ApplicationModels;
using Models.EntityModels;
using Models.ViewModels;
using Services.PhotoService;

namespace Services.WorkerService.Implementation
{
    public class WorkerService : IWorkerService
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IPhotoService _photoService;

        public WorkerService(IApplicationContext applicationContext, IPhotoService photoService)
        {
            _applicationContext = applicationContext;
            _photoService = photoService;
        }

        public Result AddWorker(AdminWorker adminWorker)
        {
            var worker = AutoMapper.Mapper.Map<Worker>(adminWorker);
            if (adminWorker.Photo != null)
            {
                var result = _photoService.AddWorkerPhoto(adminWorker.Photo, String.Format("{0}{1}", worker.FirstName.ToLower(), worker.LastName.ToLower()));
                if (result.Success)
                {
                    worker.HasPhoto = true;
                    worker.Photo = result.Data;
                }
            }
            _applicationContext.Workers.Add(worker);
            _applicationContext.SaveChanges();
            return new Result(true,null,"");
        }

        public Result EditWorker(AdminWorker adminWorker, int id)
        {
            var worker = Enumerable.FirstOrDefault(_applicationContext.Workers.Where(obj => obj.Id == id));
            if (adminWorker.Photo != null)
            {
                var result = _photoService.ReplaceWorkerPhoto(adminWorker.Photo, String.Format("{0}{1}", worker.FirstName.ToLower(), worker.LastName.ToLower()), worker.Photo);
                if (result.Success)
                {
                    worker.HasPhoto = true;
                    worker.Photo = result.Data;
                }
            }
            worker.FirstName = adminWorker.FirstName;
            worker.LastName = adminWorker.LastName;
            worker.Email = adminWorker.Email;
            worker.PhoneFirst = adminWorker.PhoneFirst;
            worker.PhoneSecond = adminWorker.PhoneSecond;
            _applicationContext.SaveChanges();

            return new Result(true,null,"");
        }
    }
}