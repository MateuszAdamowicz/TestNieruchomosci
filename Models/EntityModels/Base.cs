using System;

namespace Models.EntityModels
{
    public class Base
    {
        public Base()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Deleted { get; set; }

    }
}