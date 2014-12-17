using Context;
using Models.ViewModels;

namespace Services.Home
{
    public class CounterService : ICounterService
    {
        private readonly ISearchService _searchService;
        private readonly IApplicationContext _applicationContext;
        private readonly IStatisticesService _statisticesService;

        public CounterService(ISearchService searchService, IApplicationContext applicationContext, IStatisticesService statisticesService)
        {
            _searchService = searchService;
            _applicationContext = applicationContext;
            _statisticesService = statisticesService;
        }

        public void AddHit(string key)
        {
            var parsedSearch = _searchService.ParseKey(key);

            if (parsedSearch.Id != 0)
            {
                if (parsedSearch.AdType == AdType.Flat)
                {
                    var flat = _applicationContext.Flats.Find(parsedSearch.Id);
                    flat.Counter += 1;
                }
                else if (parsedSearch.AdType == AdType.House)
                {
                    var house = _applicationContext.Houses.Find(parsedSearch.Id);
                    house.Counter += 1;
                }
                else
                {
                    var land = _applicationContext.Lands.Find(parsedSearch.Id);
                    land.Counter += 1;
                }

                _statisticesService.AddDailyView(key);

                _applicationContext.SaveChanges();
            }
        } 
    }
}