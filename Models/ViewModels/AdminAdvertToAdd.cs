using System.Collections.Generic;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class AdminAdvertToAdd
    {
        public AdminAdvertToAdd()
        {
            Flat = new AdminFlat();
            Land = new AdminLand();
            House = new AdminHouse();
        }

        public AdminFlat Flat { get; set; }
        public AdminLand Land { get; set; }
        public AdminHouse House { get; set; }
        public AdType AdType { get; set; }
    }
}