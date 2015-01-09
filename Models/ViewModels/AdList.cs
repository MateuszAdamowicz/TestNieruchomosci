using System.CodeDom;
using System.Collections.Generic;
using PagedList;

namespace Models.ViewModels
{
    public class AdList
    {
        public IPagedList<AdminAdvertToShow> Adverts { get; set; }
        public AdListFilter FilterOptions { get; set; }
    }
}