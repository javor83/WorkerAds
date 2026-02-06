using WebApplication6.Models;

namespace WebApplication6.AppInterface
{
    /// <summary>
    /// интерфейс за начините на плащане -  CRUD
    /// </summary>
    public interface IServiceWageTax
    {


        Task Create(DTO_WageTax entity);

        IEnumerable<DTO_WageTax> Read();


        Task Update(DTO_WageTax entity);

        Task Delete(int id);


        bool Exists(int id);

        DTO_WageTax To_DTO_WageTax(int id);
    }
}
