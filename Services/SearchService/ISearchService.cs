using Models.ApplicationModels;

namespace Services.SearchService
{
    public interface ISearchService
    {
        ParsedSearch ParseKey(string key);
    }
}