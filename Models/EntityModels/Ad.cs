using System.Collections.Generic;
using Models.EntityModels.Interfaces;

namespace Models.EntityModels
{
    public class Ad : Base, IAd
    {
        public Ad()
        {
            Counter = 0;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public string Price { get; set; }
        public virtual Worker Worker { get; set; }
        public bool Visible { get; set; }
        public bool Deleted { get; set; }
        public virtual List<Photo> Pictures { get; set; }
        public int Counter { get; set; }
    }
}