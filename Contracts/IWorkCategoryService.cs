using GCommon.Models;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за работните категории
    /// </summary>
    public interface IWorkCategoryService
    {
        IEnumerable<TaxCategoryViewModel> Read();

        Task Insert(TaxCategoryViewModel sender);

        Task Delete(int id);

        bool Exists(int id);

        Task Update(TaxCategoryViewModel sender);

        TaxCategoryViewModel To_DTO_WorkCategory(int id);
    }
}
