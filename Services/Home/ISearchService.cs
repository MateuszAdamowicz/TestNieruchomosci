using Models.ApplicationModels;

namespace Services.Home
{
    public interface ISearchService
    {
        ParsedSearch ParseKey(string key);
    }
}