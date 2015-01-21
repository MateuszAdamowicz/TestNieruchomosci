using System;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class ShowAdvertList
    {
        public int Price { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public ShowListPhoto Image { get; set; }
        public string Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Area { get; set; }
        public bool ToLet { get; set; }
        public AdType AdType { get; set; }
    }
}