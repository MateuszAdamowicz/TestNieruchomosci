using System.Collections.Generic;
using System.Linq;
using Context;
using Models.EntityModels;

namespace Services.GenericRepository.Implementation
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetSet<T>() where T: Base
        {
            return _context.Set<T>().Where(x => !x.Deleted);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}