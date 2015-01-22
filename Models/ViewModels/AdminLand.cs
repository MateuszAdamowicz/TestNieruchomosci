using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models.Resources;

namespace Models.ViewModels
{
    public class AdminLand
    {
        [Display(Name = "Lokalizacja")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]       
        public string Location { get; set; }

        [Display(Name = "Powierzchnia")]
        //[RegularExpression(@"([0-9]+\.[0-9]+m2?)|([0-9]+m2?)", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "AreaAdvertNotValid")]        
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]                
        public int Area { get; set; }

        [Display(Name = "Forma w�asno�ci")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string Ownership { get; set; }

        [Display(Name = "Tytu�")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Title { get; set; } 

        [Display(Name = "Opis")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "DescriptionRequired")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]       
        public string Description { get; set; }

        [Display(Name = "Szczeg�y")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string Details { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "CityRequired")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string City { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceRequired")]
        //[RegularExpression(@"([0-9]+\.[0-9]+)|([0-9]+)|(Do negocjacji)", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceAdvertNotValid")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]       
        public int Price { get; set; } 

        public int Worker { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public MapCords Cords { get; set; }
    }
}