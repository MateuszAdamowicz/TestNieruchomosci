using System.Collections.Generic;
using Models.ViewModels;

namespace Models.EntityModels
{
    public class Statistics: Base
    {
        public virtual List<Session> Sessions { get; set; }
        public virtual List<Visit> Visits { get; set; }
    }
}