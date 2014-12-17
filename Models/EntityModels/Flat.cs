using Models.EntityModels.Interfaces;

namespace Models.EntityModels
{
    public class Flat :Ad, IFlat
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
    }
}