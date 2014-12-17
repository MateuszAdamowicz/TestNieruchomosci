using Models.ApplicationModels;

namespace Services.Home
{
    public interface IStatisticesService
    {
        Result AddDailyUser(string session);
        Result AddDailyView(string number);
    }
}