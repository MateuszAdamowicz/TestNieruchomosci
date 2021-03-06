﻿using System;

namespace Models.EntityModels.Interfaces
{
    public interface ILand
    {
        int Area { get; set; }
        string Ownership { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Details { get; set; }
        string City { get; set; }
        int Price { get; set; }
        Worker Worker { get; set; }
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        bool Visible { get; set; }
        bool Deleted { get; set; }
    }
}