using System;
using System.Collections.Generic;

namespace Models.ViewModels
{
    public class AdListFilter
    {
        public string Key { get; set; }
        public string Worker { get; set; }
        public bool? ShowHidden { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool Flat { get; set; }
        public bool House { get; set; }
        public bool Land { get; set; }
        public IEnumerable<AdType> Type
        {
            get
            {
                var types = new List<AdType>();
                if (Flat)
                {
                    types.Add(AdType.Flat);
                }
                if (House)
                {
                    types.Add(AdType.House);
                }
                if (Land)
                {
                    types.Add(AdType.Land);
                }

                return types;
            }
        }
    }
}