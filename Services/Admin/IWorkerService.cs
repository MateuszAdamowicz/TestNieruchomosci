using Models.ApplicationModels;
using Models.ViewModels;

namespace Services.Admin
{
    public interface IWorkerService
    {
        Result AddWorker(AdminWorker adminWorker);
        Result EditWorker(AdminWorker adminWorker, int id);
    }
}