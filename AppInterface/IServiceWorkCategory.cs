using WebApplication6.Models;

namespace WebApplication6.AppInterface
{
    public interface IServiceWorkCategory
    {
        IEnumerable<DTO_WorkCategory> Read();

        Task Insert(DTO_WorkCategory sender);

        Task Delete(int id);

        bool Exists(int id);

        Task Update(DTO_WorkCategory sender);

        DTO_WorkCategory To_DTO_WorkCategory(int id);
    }
}
