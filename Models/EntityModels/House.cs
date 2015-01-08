using Models.EntityModels.Interfaces;

namespace Models.EntityModels
{
    public class House: Ad, IHouse
    {
        public string Location { get; set; }
        public string LandArea { get; set; }
        public string UsableArea { get; set; }
        public string TechnicalCondition { get; set; }
        public int Rooms { get; set; }
        public string Heating { get; set; }
        public string Rent  { get; set; }
        public string Ownership { get; set; }
        public string PricePerMeter { get; set; }
        public bool ToLet { get; set; }
    }
}