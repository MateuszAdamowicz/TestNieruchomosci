using Models.ViewModels;

namespace Services.CalcService
{
    public interface ICalcService
    {
        CalcViewModel BuildViewModel();
        CalcViewModel BuildViewModel(string viewPrice, string viewOwnership);
    }
}