using GCommon.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    public class TController : Controller
    {
        public IActionResult Index()
        {
           return View(new SM() { OrderDetails = "'", Phone="466454465" });
        }
    }
}
