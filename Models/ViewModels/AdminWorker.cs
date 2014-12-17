using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models.Resources;

namespace Models.ViewModels
{
    public class AdminWorker
    {
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "FirstNameRequired")]
        public string FirstName { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "LastNameRequired")]
        public string LastName { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PhoneFirstRequired")]
        public string PhoneFirst { get; set; }
        public string PhoneSecond { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "EmailRequired")]
        public string Email { get; set; }
        public string OldPhoto { get; set; }
        public HttpPostedFileBase Photo { get; set; }
    }
}