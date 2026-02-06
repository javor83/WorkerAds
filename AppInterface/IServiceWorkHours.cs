using WebApplication6.Models;

namespace WebApplication6.AppInterface
{
    public interface IServiceWorkHours
    {
        IEnumerable<DTO_WorkHour> Read();

        Task Insert(DTO_WorkHour sender);

        bool Exists(int id);

        Task Update(DTO_WorkHour sender);

        DTO_WorkHour To_DTO_WorkHour(int id);

        Task Delete(int id);

    }
}
