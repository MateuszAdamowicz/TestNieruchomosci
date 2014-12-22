using Models.ViewModels;

namespace Services.Home
{
    public interface IOfferService
    {
        void AddOffer(CreateOffer createOffer);
        void DeleteOffer(int id);
    }
}