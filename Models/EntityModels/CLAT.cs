using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Resources;

namespace Models.EntityModels
{
    public class Clat : Base, IValidatableObject 
    {
        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsFromRequired")]
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsFromRange")]
        public double From { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsToRequired")]
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsToRange")]
        public double To { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsPercentRequired")]
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsPercentRange")]
        public double Percent { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsMaxRequired")]
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsMaxRange")]
        public double Max { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsPriceRequired")]
        [Range(0, Double.MaxValue, ErrorMessageResourceType = typeof(StringResource), ErrorMessageResourceName = "SettingsPriceRange")]
        public double Price { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
     { 
         if (To < From)
         { 
             yield return new ValidationResult
              ("Wartość “Do” nie moze byc mniejsza od wartości “Od”", new[] { "From" }); 
         }

         if (From > To)
         {
             yield return new ValidationResult
              ("Wartość “Od” nie moze byc większa od wartości “Do”", new[] { "To" });
         } 
     } 
    }
}
