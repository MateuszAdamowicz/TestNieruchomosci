using Context;
using Models.EntityModels;
using Models.ViewModels;

namespace Services.CreateOfferService.Implementation
{
    public class OfferService : IOfferService
    {
        private readonly IApplicationContext _applicationContext;

        public OfferService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void AddOffer(CreateOffer createOffer)
        {
            var offer = AutoMapper.Mapper.Map<Offer>(createOffer);
            _applicationContext.Offers.Add(offer);
            _applicationContext.SaveChanges();
        }

        public void DeleteOffer(int id)
        {
            var offer = _applicationContext.Offers.Find(id);

            if (offer != null)
            {
                offer.Deleted = true;
            }
            _applicationContext.SaveChanges();
        }
    }
}