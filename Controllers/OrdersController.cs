using GCommon.Contracts;
using GCommon.ExtensionAttributes;
using GCommon.Models;
using GCommon.Navigation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace WebApplication6.Controllers
{
    [AuthorizeAdmin]
    public class OrdersController(IManageOrders _manage) : Controller
    {

        //************************************************************************************************
        public IActionResult Index()
        {
            IEnumerable<ManageOrderItemViewModel> list = _manage.Read();
            return View(list);
        }
        //************************************************************************************************
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _manage.Delete(id);
            return RedirectToAction
                (
                    ControllerNavigateViewModel.Orders_Index,
                    ControllerNavigateViewModel.Orders
                );
        }
        //************************************************************************************************
    }
}
