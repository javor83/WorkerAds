using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    public interface IWorkerService
    {
        IEnumerable<WorkerSelect> Read();

        Task Insert(InsertWorker sender);

        Task<bool> Delete(int id);

        Task Update(UpdateWorker sender);

        UpdateWorker Find(int id);

    }
}
