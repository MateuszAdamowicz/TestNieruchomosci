using Models;
using Models.ApplicationModels;

namespace Services.Home.EmailService
{
    public interface IEmailStorageService
    {
        Result SaveEmail(ContactEmail contactEmail);
    }
}