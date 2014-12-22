using Models.ViewModels;

namespace Services.Home
{
    public interface ICreateOfferService
    {
        void AddOffer(CreateOffer createOffer);
    }
}