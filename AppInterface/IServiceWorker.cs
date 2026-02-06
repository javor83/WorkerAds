using WebApplication6.Models;

namespace WebApplication6.AppInterface
{
    public interface IServiceWorker
    {
        IEnumerable<DTO_WorkerSelect> Read();

        Task Insert(DTO_InsertWorker sender);

        Task<bool> Delete(int id);

        Task Update(DTO_UpdateWorker sender);

        DTO_UpdateWorker Find(int id);

    }
}
