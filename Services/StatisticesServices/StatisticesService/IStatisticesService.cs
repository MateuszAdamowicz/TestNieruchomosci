using Models.ApplicationModels;

namespace Services.StatisticesServices.StatisticesService
{
    public interface IStatisticesService
    {
        Result AddDailyUser(string session);
        Result AddDailyView(string number);
    }
}