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
        public string Storey { get; set; }
        public string TechnicalCondition { get; set; }
        public string Rooms { get; set; }
        public string Heating { get; set; }
        public string Rent { get; set; }
        public string Ownership { get; set; }
        public string PricePerMeter { get; set; }
        public bool ToLet { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "DescriptionRequired")]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "CityRequired")]
        public string City { get; set; }
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "PriceRequired")]
        public string Price { get; set; }
        public int Worker { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}