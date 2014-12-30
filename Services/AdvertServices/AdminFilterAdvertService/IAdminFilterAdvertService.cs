using System;
using System.Collections.Generic;
using Models.ViewModels;

namespace Services.AdvertServices.AdminFilterAdvertService
{
    public interface IAdminFilterAdvertService
    {
        IEnumerable<AdminAdvertToShow> FilterAdverts(string key, string worker, bool? showHidden, DateTime? dateFrom, DateTime? dateTo, IEnumerable<AdType> type);
        IEnumerable<AdminAdvertToShow> ActiveAdverts(bool? hidden);
    }
}