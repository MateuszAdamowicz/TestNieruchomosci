using System.Collections.Generic;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class EditHouse: AdminHouse
    {
        public List<Photo> Pictures { get; set; }
        public List<int> ToDeleted { get; set; }
    }
}