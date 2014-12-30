using System;

namespace Models.EntityModels.Interfaces
{
    public interface IBase
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        bool Deleted { get; set; }
    }
}