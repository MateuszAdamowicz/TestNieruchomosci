using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models.Resources;

namespace Models.ViewModels
{
    public class AdminFlat
    {
        public string Location { get; set; }
        public string Area { get; set; }
        [Range(0, 100, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "StoreyRange")]
        public int Storey { get; set; }
        public string TechnicalCondition { get; set; }
        [Range(0, 100, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "RoomsRange")]
        public int Rooms { get; set; }
        public string Heating { get; set; }
        public string Rent { get; set; }
        public string Ownership { get; set; }
        public string PricePerMeter { get; set; }
        public bool ToLet { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleMaxLength")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "DescriptionRequired")]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "CityRequired")]
        [MaxLength(40, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "CityMaxLength")]
        public string City { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceRequired")]
        [RegularExpression(@"([0-9]+\.[0-9]+)|([0-9]+)|(Do negocjacji)", ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceAdvertNotValid")]
        public string Price { get; set; }
        public int Worker { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}