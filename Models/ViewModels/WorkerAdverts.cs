using System.Collections.Generic;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class WorkerAdverts: Worker
    {
        public IEnumerable<NewestAdvert> Adverts { get; set; }
    }
}