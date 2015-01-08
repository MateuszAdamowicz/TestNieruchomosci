using System.ComponentModel.DataAnnotations;
using Models.Resources;

namespace Models
{
    public class ContactEmail
    {
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "FullNameRequired")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "FullNameMaxLength")]
        public string FullName { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid")]
        [EmailAddress(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid", ErrorMessage = null)]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailMaxLength")]
        public string Email { get; set; }

        [RegularExpression("[0-9]{6,18}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNotValid")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "BodyRequired")]
        public string Body { get; set; }
        
        public string OfferLink { get; set; }
    }
}