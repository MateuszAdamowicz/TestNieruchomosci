using Models.ViewModels;

namespace Services.CreateOfferService
{
    public interface IOfferService
    {
        void AddOffer(CreateOffer createOffer);
        void DeleteOffer(int id);
    }
}