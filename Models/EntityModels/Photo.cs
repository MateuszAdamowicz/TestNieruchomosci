using Models.ViewModels;

namespace Models.EntityModels
{
    public class Photo: Base
    {
        public string Link { get; set; }
        public AdType AdType { get; set; }
        public virtual Flat Flat { get; set; }
        public virtual House House { get; set; }
        public virtual Land Land { get; set; }
        public string Min { get; set; }
    }
}