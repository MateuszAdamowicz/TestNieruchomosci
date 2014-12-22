using System.ComponentModel.DataAnnotations;
using Models.Resources;

namespace Models
{
    public class ContactEmail
    {
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "FullNameRequired")]
        public string FullName { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid")]
        [EmailAddress(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "BodyRequired")]
        public string Body { get; set; }
        
        public string OfferLink { get; set; }
    }
}