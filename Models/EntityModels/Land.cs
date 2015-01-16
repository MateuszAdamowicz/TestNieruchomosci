using Models.EntityModels.Interfaces;

namespace Models.EntityModels
{
    public class Land: Ad, ILand
    {
        public int Area { get; set; }
        public string Ownership { get; set; }
        public string Location { get; set; }
    }
}