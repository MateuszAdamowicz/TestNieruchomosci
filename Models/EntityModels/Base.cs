using System;
using Models.EntityModels.Interfaces;

namespace Models.EntityModels
{
    public class Base : IBase
    {
        public Base()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}