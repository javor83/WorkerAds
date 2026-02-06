using WebApplication6.DatabaseModels;

namespace WebApplication6.Models
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
