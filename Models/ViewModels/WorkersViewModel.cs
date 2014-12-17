using System.Collections.Generic;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class WorkersViewModel
    {
        public IEnumerable<Worker> Workers { get; set; }
        public Response Response { get; set; }
    }
}