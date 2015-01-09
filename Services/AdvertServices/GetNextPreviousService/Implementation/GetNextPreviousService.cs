using System.Linq;
using AutoMapper;
using Models.EntityModels;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.AdvertServices.GetNextPreviousService.Implementation
{
    public class GetNextPreviousService : IGetNextPreviousService
    {
        private readonly IGenericRepository _genericRepository;

        public GetNextPreviousService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public AdvertNeighbours<TT> GetNeighbours<T, TT>(int id) 
            where T : Ad
            where TT: ShowAd
        {
            var set = _genericRepository.GetSet<T>();
            var previous = set
                .Where(x => x.Visible && x.Id < id)
                .OrderByDescending(x => x.Id);

            var next = set
                .Where(x => x.Visible && x.Id > id)
                .OrderBy(x => x.Id);

            var showPrevious = Mapper.Map<TT>(previous.FirstOrDefault());
            var showNext = Mapper.Map<TT>(next.FirstOrDefault());

            var neighbours = new AdvertNeighbours<TT>()
            {
                Next = showNext,
                Previous = showPrevious
            };

            return neighbours;
        } 
    }
}