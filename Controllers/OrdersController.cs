using GCommon.Contracts;
using GCommon.ExtensionAttributes;
using GCommon.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    [AuthorizeAdmin]
    public class OrdersController(IManageOrders _manage) : Controller
    {
  
        public IActionResult Index()
        {
            IEnumerable<ManageOrderItemViewModel> list = _manage.Read();
            return View(list);
        }
    }
}
