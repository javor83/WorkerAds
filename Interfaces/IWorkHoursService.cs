using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    public interface IWorkHoursService
    {
        IEnumerable<WorkHour> Read();

        Task Insert(WorkHour sender);

        bool Exists(int id);

        Task Update(WorkHour sender);

        WorkHour To_DTO_WorkHour(int id);

        Task Delete(int id);

    }
}
