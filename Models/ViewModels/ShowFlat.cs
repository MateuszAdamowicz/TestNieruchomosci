using System.Collections.Generic;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class ShowFlat : ShowAd
    {
        public ShowFlat()
        {
            ContactEmail = new ContactEmail();
        }

        public string Location { get; set; }
        public int Area { get; set; }
        public string Storey { get; set; }
        public string TechnicalCondition { get; set; }
        public string Rooms { get; set; }
        public string Heating { get; set; }
        public string Rent { get; set; }
        public string Ownership { get; set; }
        public string PricePerMeter { get; set; }
        public bool ToLet { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public bool Visible { get; set; }
        public bool Deleted { get; set; }
        public virtual List<Photo> Pictures { get; set; }
        public ContactEmail ContactEmail { get; set; }
        public string Number { get; set; }
        public int Counter { get; set; }
    }
}