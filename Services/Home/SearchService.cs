using System;
using System.Linq;
/*
 * key = {id*9999}{adType}
 * adType:
 *      12 - AdType.Flat
 *      14 - AdType.House
 *      18 - AdType.Land
 *      
 * eg. key = 43995614
 *      id = 44, adType = AdType.House
 */
using Models.ApplicationModels;
using Models.ViewModels;

namespace Services.Home
{
    public class SearchService : ISearchService
    {
        public ParsedSearch ParseKey(string key)
        {
            AdType typeParsed = AdType.Flat;
            int idParsed;
            if (String.IsNullOrEmpty(key) || key.Count() < 2)
            {
                idParsed = 0;
            }
            else
            {
                var id = key.Substring(0, key.Count() - 2);
                Int32.TryParse(id, out idParsed);
                if (idParsed%9999 != 0)
                {
                    idParsed = 0;
                }
                else
                {
                    idParsed = idParsed / 9999;
                }
                var type = key.Substring(key.Count() - 2, 2);

                if (type == "12")
                {
                    typeParsed = AdType.Flat;
                }
                else if (type == "14")
                {
                    typeParsed = AdType.House;
                }
                else if (type == "18")
                {
                    typeParsed = AdType.Land;
                }
                else
                {
                    idParsed = 0;
                }
            }


            var parsedSearch = new ParsedSearch()
            {
                AdType = typeParsed,
                Id = idParsed
            };

            return parsedSearch;
        }
    }
}