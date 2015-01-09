using System;
using System.Collections.Generic;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class ShowLand : ShowAd
    {
        public ShowLand()
        {
            ContactEmail = new ContactEmail();
        }

        public ShowWorker Worker { get; set; }
        public string Area { get; set; }
        public string Ownership { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public string Price { get; set; }
        public bool Visible { get; set; }
        public bool Deleted { get; set; }
        public virtual List<Photo> Pictures { get; set; }
        public ContactEmail ContactEmail { get; set; }
        public string Number { get; set; }
        public int Counter { get; set; }
    }
}