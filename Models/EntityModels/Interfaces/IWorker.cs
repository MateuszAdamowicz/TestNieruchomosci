using System;

namespace Models.EntityModels.Interfaces
{
    public interface IWorker
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string[] PhoneNumbers { get; set; }
        string Email { get; set; }
        int Id { get; set; }
        DateTime? CreatedAt { get; set; }
    }
}