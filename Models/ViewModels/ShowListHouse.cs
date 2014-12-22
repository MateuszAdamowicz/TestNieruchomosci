using System;

namespace Models.ViewModels
{
    public class ShowListHouse
    {
        public int Id { get; set; }
        public string UsableArea { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Rent { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Rooms { get; set; }
        public virtual ShowListPhoto Picture { get; set; }
        public string ToLet { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Number { get; set; }
    }
}