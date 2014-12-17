using System.Collections.Generic;
using System.Web;
using Models.ApplicationModels;
using Models.EntityModels;

namespace Services.Admin
{
    public interface IPhotoService
    {
        Result<string> AddWorkerPhoto(HttpPostedFileBase file, string fileName);
        List<Photo> AddAdvertPhotos(IEnumerable<HttpPostedFileBase> files);
        Result<string> ReplaceWorkerPhoto(HttpPostedFileBase file, string fileName, string oldPhoto);
    }
}