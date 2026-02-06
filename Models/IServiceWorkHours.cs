using WebApplication6.DatabaseModels;

namespace WebApplication6.Models
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
