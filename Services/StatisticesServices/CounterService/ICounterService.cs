namespace Services.StatisticesServices.CounterService
{
    public interface ICounterService
    {
        void AddHit(string key);
    }
}