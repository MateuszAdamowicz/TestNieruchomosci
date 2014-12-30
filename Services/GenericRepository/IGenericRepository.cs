using System.Collections.Generic;
using Models.EntityModels;

namespace Services.GenericRepository
{
    public interface IGenericRepository
    {
        IEnumerable<T> GetSet<T>() where T: Base;
        void SaveChanges();
    }
}