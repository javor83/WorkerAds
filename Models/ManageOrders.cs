using GCommon.Contracts;
using GCommon.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GCommon.Models
{
    public class ManageOrders(MeisterContext _context) : IManageOrders
    {

        //********************************************************************************
        /// <summary>
        /// изтриване поръчка
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async Task IManageOrders.Delete(int id)
        {
            var query = _context.AspnetuserOrders.Where(x => x.OrderId == id).First();
            if (query != null)
            {
                _context.AspnetuserOrders.Remove(query);
                await _context.SaveChangesAsync();
            }
        }


        //********************************************************************************
        /// <summary>
        /// четене на всички поръчки
        /// </summary>
        /// <returns></returns>
        IEnumerable<ManageOrderItemViewModel> IManageOrders.Read()
        {
           var query = from orders in _context.AspnetuserOrders

                        join item_in_order in _context.ItemsInOrders
                        on orders.OrderId equals item_in_order.OrderId

                        join decl_worker_free in _context.DeclareWorkerFrees
                        on item_in_order.DeclareWorkerFreeId equals decl_worker_free.Id

                        orderby orders.OrderDate descending



                       select new ManageOrderItemViewModel()
                       {
                           ID = orders.OrderId,
                           OrderDate = orders.OrderDate,
                           Phone = orders.Phone,
                           OrderDetails = orders.OrderDetails,
                           AdvertisementTitle = decl_worker_free.AdTitle
                       };


            return query;

        }
    }
}
