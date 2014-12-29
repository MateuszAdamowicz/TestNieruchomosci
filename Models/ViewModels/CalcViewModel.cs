using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class CalcViewModel
    {
        public List<Clat> ClatList { get; set; }
        public List<CostProperty> CostPropertiesList { get; set; }
        public CalcView ModelCalcView { get; set; }
    }
}
