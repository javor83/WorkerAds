using GCommon.Models;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за начините на плащане -  CRUD
    /// </summary>
    public interface IWageTaxService
    {


        Task Create(WageTaxViewModel entity);

        IEnumerable<WageTaxViewModel> Read();


        Task Update(WageTaxViewModel entity);

        Task Delete(int id);


        bool Exists(int id);

        WageTaxViewModel To_DTO_WageTax(int id);
    }
}
