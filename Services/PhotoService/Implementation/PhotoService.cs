using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using Context;
using Models.ApplicationModels;
using Models.EntityModels;
using Services.ResizeImageService.Implementataion;

namespace Services.PhotoService.Implementation
{
    public class PhotoService : IPhotoService
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IResizeImageService _resizeImageService;

        public PhotoService(IApplicationContext applicationContext, IResizeImageService resizeImageService)
        {
            _applicationContext = applicationContext;
            _resizeImageService = resizeImageService;
        }

        public Result<string> AddWorkerPhoto(HttpPostedFileBase file, string fileName)
        {
            if (file != null && file.ContentLength > 0)
            {
                var path = HttpContext.Current.Server.MapPath("~/Content/Photos/Workers/");
                file.SaveAs(path + fileName + Path.GetExtension(file.FileName));

                var resized =
                    _resizeImageService.ResizeImage(Image.FromFile(path + fileName + Path.GetExtension(file.FileName)), 170, 120);

                var minPath = path + "min_" + fileName + Path.GetExtension(file.FileName);

                resized.Save(minPath);

                return new Result<string>(true, null, "", fileName + Path.GetExtension(file.FileName));
            
            }
            return new Result<string>(false, null, "",String.Empty);
        }

        public Result<string> ReplaceWorkerPhoto(HttpPostedFileBase file, string fileName, string oldPhoto)
        {
            if (file != null && file.ContentLength > 0)
            {
                var path = HttpContext.Current.Server.MapPath("~/Content/Photos/Workers/");
                if (!String.IsNullOrEmpty(oldPhoto))
                {
                    File.Delete(path + oldPhoto);
                }

                return AddWorkerPhoto(file,fileName);
            }
            return new Result<string>(false, null, "",String.Empty);
        }

        public List<Photo> AddAdvertPhotos(IEnumerable<HttpPostedFileBase> files)
        {
            var pictures = new List<Photo>();
            if (files != null && files.Any())
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = String.Format("{0}_{1}", DateTime.Now.ToString("FFFFFFF"), file.FileName);
                        var path = HttpContext.Current.Server.MapPath("~/Content/Photos/");
                        file.SaveAs(path + fileName);
                        var resized =
                   _resizeImageService.ResizeImage(Image.FromFile(path + fileName), 170, 120);

                        var minPath = path + "min_"+fileName;

                        resized.Save(minPath);
                        pictures.Add(new Photo() { Link = fileName, Min = "min_"+fileName});
                    }
                }
            }

            return pictures;
        }
    }
}