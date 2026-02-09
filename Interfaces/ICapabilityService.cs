using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    /// <summary>
    /// интерфейс за способностите на човека
    /// </summary>
    public interface ICapabilityService
    {
        IEnumerable<WageTax> GetWageTax();
        IEnumerable<TaxCategory> GetCategory();

        IEnumerable<SelectWorkCapability> CapalityList(int worker_id);

        string WorkerName(int worker_id);

        Task InsertCapability(WorkCapability sender);

        WorkCapability EditCapability(int capability_id);

        Task DeleteCapabilty(int id);

        IEnumerable<SelectListItem> ComboWageTax(IEnumerable<WageTax> sender);
        IEnumerable<SelectListItem> ComboCategory(IEnumerable<TaxCategory> sender);


        Task UpdateCapability(WorkCapability sender);

    }
}
