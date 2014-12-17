using System;
using System.Collections.Generic;
using Models.ViewModels;

namespace Services.Admin
{
    public interface IAdminFilterService
    {
        IEnumerable<AdminAdvertToShow> FilterAdverts(string key, string worker, bool? showHidden, DateTime? dateFrom, DateTime? dateTo, IEnumerable<AdType> type);
        IEnumerable<AdminAdvertToShow> ActiveAdverts(bool? hidden);
    }
}