using System.Collections.Generic;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class EditFlat: AdminFlat
    {
        public List<Photo> Pictures { get; set; }
        public List<int> ToDeleted { get; set; }
    }
}