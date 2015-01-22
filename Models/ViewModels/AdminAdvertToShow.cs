using System;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class AdminAdvertToShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public bool Visible { get; set; }
        public AdType AdType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Number { get; set; }
        public bool  Deleted { get; set; }
    }
}