using System;
using System.Collections.Generic;
using System.Security;
using System.Text.RegularExpressions;
using Models.ViewModels;

namespace Models.EntityModels
{
    public class Ad : Base
    {
        public Ad()
        {
            Counter = 0;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public bool Visible { get; set; }
        public virtual List<Photo> Pictures { get; set; }
        public int Counter { get; set; }
        public MapCords Cords { get; set; }
    }
}