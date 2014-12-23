using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class CostProperty:Base
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public PropertyType Type { get; set; }

    }
}

