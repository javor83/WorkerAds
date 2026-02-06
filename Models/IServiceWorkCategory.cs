using System.Reflection;
using WebApplication6.DatabaseModels;

namespace WebApplication6.Models
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
