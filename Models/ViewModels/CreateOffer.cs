using System.ComponentModel.DataAnnotations;
using Models.Resources;

namespace Models.ViewModels
{
    public class CreateOffer
    {
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "FullNameRequired")]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid")]
        [EmailAddress(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid", ErrorMessage = null)]
        public string Email { get; set; }

        [RegularExpression("[0-9]{0,7}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceNotValid")]
        public string Price { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNumberRequired")]
        [RegularExpression("[0-9]{6,18}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNotValid")]
        public string PhoneNumber { get; set; }
        public AdType AdType { get; set; }
    }
}