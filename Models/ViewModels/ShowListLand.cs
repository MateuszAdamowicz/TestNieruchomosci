using System;

namespace Models.ViewModels
{
    public class ShowListLand
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public virtual ShowListPhoto Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Number { get; set; }
    }
}