using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models.Resources;

namespace Models.ViewModels
{
    public class AdminHouse
    {
        [Display(Name = "Lokalizacja")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string Location { get; set; }

        [Display(Name = "Powierzchnia całkowita")]
        //[RegularExpression(@"([0-9]+\.[0-9]+m2?)|([0-9]+m2?)", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "AreaAdvertNotValid")]     
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public int LandArea { get; set; }
        
        [Display(Name = "Powierzchnia użytkowa")]
        //[RegularExpression(@"([0-9]+\.[0-9]+m2?)|([0-9]+m2?)", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "AreaAdvertNotValid")]     
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]       
        public int UsableArea { get; set; }
        
        [Display(Name = "Stan techniczny")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string TechnicalCondition { get; set; }
        
        [Range(0, 100, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "RoomsRange")]
        public int Rooms { get; set; }
        
        [Display(Name = "Ogrzewanie")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]    
        public string Heating { get; set; }

        [Display(Name = "Czynsz")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string Rent { get; set; }

        [Display(Name = "Forma własności")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]       
        public string Ownership { get; set; }

        [Display(Name = "Cena za m2")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string PricePerMeter { get; set; }
        public bool ToLet { get; set; }

        [Display(Name="Tytuł")]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "DescriptionRequired")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string Description { get; set; }

        [Display(Name = "Szczegóły")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "MaxLength")]        
        public string Details { get; set; }

        [Display(Name="Miasto")]
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
    }
}