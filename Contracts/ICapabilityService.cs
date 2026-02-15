using GCommon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за способностите на човека
    /// </summary>
    public interface ICapabilityService
    {
        IEnumerable<WageTaxViewModel> GetWageTax();
        IEnumerable<TaxCategoryViewModel> GetCategory();

        IEnumerable<SelectWorkCapabilityViewModel> CapalityList(int worker_id);

        string WorkerName(int worker_id);

        Task InsertCapability(WorkCapabilityViewModel sender);

        WorkCapabilityViewModel EditCapability(int capability_id);

        Task DeleteCapabilty(int id);

        IEnumerable<SelectListItem> ComboWageTax(IEnumerable<WageTaxViewModel> sender);
        IEnumerable<SelectListItem> ComboCategory(IEnumerable<TaxCategoryViewModel> sender);


        Task UpdateCapability(WorkCapabilityViewModel sender);

    }
}
