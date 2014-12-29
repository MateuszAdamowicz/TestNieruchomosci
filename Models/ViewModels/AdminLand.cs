using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models.Resources;

namespace Models.ViewModels
{
    public class AdminLand
    {
        public string Location { get; set; } // 
        public string Area { get; set; } // 
        public string Ownership { get; set; } // 
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleMaxLength")]
        public string Title { get; set; } // 
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "DescriptionRequired")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } //
        [DataType(DataType.MultilineText)]
        public string Details { get; set; } //
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "CityRequired")]
        public string City { get; set; } // 
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceRequired")]
        [RegularExpression(@"([0-9]+\.[0-9]+)|([0-9]+)|(Do negocjacji)", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceAdvertNotValid")]
        public string Price { get; set; } // 
        public int Worker { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}