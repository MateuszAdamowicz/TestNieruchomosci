using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public enum AdType
    
    {
        [Display(Name = "Mieszkanie")]
        Flat,
        [Display(Name = "Dom")]
        House,
        [Display(Name = "Działka")]
        Land
    }
}