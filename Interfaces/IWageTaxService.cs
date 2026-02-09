using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    /// <summary>
    /// интерфейс за начините на плащане -  CRUD
    /// </summary>
    public interface IWageTaxService
    {


        Task Create(WageTax entity);

        IEnumerable<WageTax> Read();


        Task Update(WageTax entity);

        Task Delete(int id);


        bool Exists(int id);

        WageTax To_DTO_WageTax(int id);
    }
}
