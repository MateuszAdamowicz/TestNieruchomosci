using Models;
using Models.ApplicationModels;
using Models.EntityModels;
using Models.ViewModels;

namespace Services.Home.EmailService
{
    public interface IEmailService
    {
        Result SendAndSaveOfferQuestion(ContactEmail contactEmail);
        Result SendAndSaveContactQuestion(ContactEmail contactEmail);
        Result SendAndSaveOfferResponse(OfferStatus offerStatus, Offer offer);
    }
}