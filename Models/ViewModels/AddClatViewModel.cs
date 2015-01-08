using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class AddClatViewModel
    {

        public Clat Clat { get; set; }
        public List<Compartments> CompartmentsList { get; set; }
    }
}
