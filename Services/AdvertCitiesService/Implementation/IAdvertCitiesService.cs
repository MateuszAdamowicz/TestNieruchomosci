using System.Collections.Generic;
using Models.EntityModels;
using Models.ViewModels;

namespace Services.AdvertCitiesService.Implementation
{
    public interface IAdvertCitiesService
    {
        List<SelectOption> GetCities<T>() where T : Ad;
        List<CityCount> GetCitiesWithRepeats(int count);
    }
}