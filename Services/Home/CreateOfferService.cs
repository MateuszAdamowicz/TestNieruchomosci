using Context;
using Models.EntityModels;
using Models.ViewModels;

namespace Services.Home
{
    public class CreateOfferService : ICreateOfferService
    {
        private readonly IApplicationContext _applicationContext;

        public CreateOfferService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void AddOffer(CreateOffer createOffer)
        {
            var offer = AutoMapper.Mapper.Map<Offer>(createOffer);
            _applicationContext.Offers.Add(offer);
            _applicationContext.SaveChanges();
        }
    }
}