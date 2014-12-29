using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class Clat:Base
    {
        public double From { get; set; }
        public double To { get; set; }
        public double Percent { get; set; }
        public double Max { get; set; }
        public double Price { get; set; }
    }
}
