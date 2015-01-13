using System.ComponentModel.DataAnnotations;
using Models.Resources;

namespace Models.ViewModels
{
    public class CreateOffer
    {
        [Display(Name="Imię i nazwisko")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "FullNameRequired")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string FullName { get; set; }

        [Display(Name = "Imię i nazwisko")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid")]
        [EmailAddress(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid", ErrorMessage = null)]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Email { get; set; }

        [Display(Name = "Cena")]        
        [RegularExpression("[0-9]{0,7}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceNotValid")]
        public string Price { get; set; }

        [Display(Name = "Miasto")] 
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string City { get; set; }

        [Display(Name = "Lokalizacja")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]                
        public string Location { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]               
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNumberRequired")]
        [RegularExpression("[0-9]{6,18}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNotValid")]
        public string PhoneNumber { get; set; }
        public AdType AdType { get; set; }
    }
}