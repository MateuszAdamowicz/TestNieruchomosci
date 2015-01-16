using System;

namespace Models.ViewModels
{
    public class NewestAdvert
    {
        public string Number { get; set; }
        public string City { get; set; }
        public string Price { get; set; }
        public bool ToLet { get; set; }
        public AdType AdType { get; set; }
        public DateTime CreatedAt { get; set; }
        public ShowListPhoto Picture { get; set; }
    }
}