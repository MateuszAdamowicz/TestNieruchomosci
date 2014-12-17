using Models.ViewModels;

namespace Models.EntityModels
{
    public class Offer: Base
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Price { get; set; }
        public AdType AdType { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public OfferStatus Status { get; set; }

    }
}