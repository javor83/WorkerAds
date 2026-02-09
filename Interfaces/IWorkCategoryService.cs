using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    public interface IWorkCategoryService
    {
        IEnumerable<TaxCategory> Read();

        Task Insert(TaxCategory sender);

        Task Delete(int id);

        bool Exists(int id);

        Task Update(TaxCategory sender);

        TaxCategory To_DTO_WorkCategory(int id);
    }
}
