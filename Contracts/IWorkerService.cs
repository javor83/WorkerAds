using GCommon.Models;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за работниците
    /// </summary>
    public interface IWorkerService
    {
        /// <summary>
        /// четене
        /// </summary>
        /// <returns></returns>
        IEnumerable<WorkerSelectViewModel> Read();
        //вмъкване
        Task Insert(InsertWorkerViewModel sender);
        /// <summary>
        /// изтриване
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(int id);

        Task Update(UpdateWorkerViewModel sender);

        UpdateWorkerViewModel Find(int id);

    }
}
