using System;
using System.Linq;
using Models.EntityModels;
using Services.GenericRepository;

namespace Services.MaxPriceService.Implementation
{
    public class MaxPriceService : IMaxPriceService
    {
        private readonly IGenericRepository _genericRepository;

        public MaxPriceService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public int GetMaxPrice()
        {
            var maxFlat = _genericRepository.GetSet<Flat>().Max(x => x.Price);
            var maxHouse = _genericRepository.GetSet<House>().Max(x => x.Price);
            var maxLand = _genericRepository.GetSet<Land>().Max(x => x.Price);
            var max = Math.Max(maxFlat, maxHouse);
            max = Math.Max(max, maxLand);

            return max;
        }
    }
}