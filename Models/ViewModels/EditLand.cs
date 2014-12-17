using System.Collections.Generic;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class EditLand: AdminLand
    {
        public List<Photo> Pictures { get; set; }
        public List<int> ToDeleted { get; set; }
    }
}