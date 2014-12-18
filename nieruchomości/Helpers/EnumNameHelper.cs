using System;
using Models.EntityModels;
using Models.ViewModels;

namespace nieruchomości.Helpers
{
    public class EnumNameHelper
    {
        public static string GetAdType(AdType adType)
        {
            if (adType == AdType.Flat)
            {
                return "Mieszkanie";
            }
            if (adType == AdType.House)
            {
                return "Dom";
            }
            return "Działka";
        }
    }
}