using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.DatabaseModels;

namespace WebApplication6.Models
{


    /// <summary>
    /// интерфейс за способностите на човека
    /// </summary>
    public interface IServiceCapability
    {
        IEnumerable<DTO_WageTax> GetWageTax();
        IEnumerable<DTO_WorkCategory> GetCategory();

        IEnumerable<DTO_SelectWorkCapability> CapalityList(int worker_id);

        string WorkerName(int worker_id);

        Task InsertCapability(DTO_WorkCapability sender);

        DTO_WorkCapability EditCapability(int capability_id);

        Task DeleteCapabilty(int id);

        IEnumerable<SelectListItem> ComboWageTax(IEnumerable<DTO_WageTax> sender);
        IEnumerable<SelectListItem> ComboCategory(IEnumerable<DTO_WorkCategory> sender);


        Task UpdateCapability(DTO_WorkCapability sender);

    }









}
