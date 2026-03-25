


using GCommon.Models;

namespace GCommon.Contracts
{
    public interface IManageOrders
    {

        IEnumerable<ManageOrderItemViewModel> Read();

        Task Delete(int id);
    }

    

 
}
