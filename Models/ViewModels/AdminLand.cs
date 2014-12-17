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
        public string Title { get; set; } // 
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "DescriptionRequired")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } //
        [DataType(DataType.MultilineText)]
        public string Details { get; set; } //
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "CityRequired")]
        public string City { get; set; } // 
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceRequired")]
        public string Price { get; set; } // 
        public int Worker { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}