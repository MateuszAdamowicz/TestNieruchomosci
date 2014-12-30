using Models.ViewModels;

namespace Services.EnumNameService.Implementation
{
    public class EnumNameService : IEnumNameService
    {
        public static string GetName(AdType adType)
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