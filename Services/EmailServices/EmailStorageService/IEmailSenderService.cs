using Models;
using Models.ApplicationModels;
using Models.ViewModels;

namespace Services.EmailServices.EmailStorageService
{
    public interface IEmailSenderService
    {
        Result SendOfferQuestion(ContactEmail contactEmail);
        Result SendContactQuestion(ContactEmail contactEmail);
        string GetOfferTemplate();
        string GetContactTemplate();
        Result SendOfferResponse(OfferStatus offerStatus, string destination);
        string GetOfferRejectedTemplate();
        string GetOfferAcceptedTemplate();
    }
}