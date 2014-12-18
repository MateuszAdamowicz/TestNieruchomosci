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
        public string Email { get; set; }
        public string Price { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNumberRequired")]
        public string PhoneNumber { get; set; }
        public AdType AdType { get; set; }
    }
}