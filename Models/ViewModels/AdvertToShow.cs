using System;

namespace Models.ViewModels
{
    public class AdvertToShow
    {
        public string Number { get; set; }
        public string Price { get; set; }
        public bool ToLet { get; set; }
        public decimal PricePerMeter { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Photo { get; set; }

    }
}