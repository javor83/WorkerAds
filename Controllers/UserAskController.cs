using GCommon.ExtensionAttributes;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    [AuthorizeUser()]
    public class UserAskController : Controller
    {
        //*********************************************************************
        public IActionResult Index()
        {
            return View();
        }
        //*********************************************************************
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult IncludeAsk(int id,int page,string kw)
        {
            return Json(new { x = id, y = page, z = kw });
            
        }
        //*********************************************************************
    }
}
