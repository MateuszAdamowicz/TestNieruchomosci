using Models;
using Models.ApplicationModels;

namespace Services.EmailServices.EmailSenderService
{
    public interface IEmailStorageService
    {
        Result SaveEmail(ContactEmail contactEmail);
    }
}