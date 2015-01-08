using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Resources;

namespace Models.EntityModels
{
    public class Clat:Base
    {
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        public double From { get; set; }

        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        public double To { get; set; }
       
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        public double Percent { get; set; }
        
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        public double Max { get; set; }
        
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "TitleRequired")]
        public double Price { get; set; }
    }
}
