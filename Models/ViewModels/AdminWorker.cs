using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models.Resources;

namespace Models.ViewModels
{
    public class AdminWorker
    {
        [Display(Name="Imię")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "FirstNameRequired")]
        [MaxLength(20, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "LastNameRequired")]
        [MaxLength(30, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneFirstRequired")]
        [RegularExpression("[0-9]{6,18}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNotValid")]
        public string PhoneFirst { get; set; }
        [RegularExpression("[0-9]{6,18}", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneNotValid")]
        public string PhoneSecond { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid")]
        [EmailAddress(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailNotValid", ErrorMessage = null)]
        public string Email { get; set; }
        public string OldPhoto { get; set; }
        public HttpPostedFileBase Photo { get; set; }
    }
}