using GCommon.Contracts;
using GCommon.ExtensionAttributes;
using GCommon.Models;
using GCommon.Navigation;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    [AuthorizeUser()]
    public class UserAskController : Controller
    {
       
        private IManageAsk _manage_ask = null;
        public UserAskController(IManageAsk manage_ask  )
        {
            this._manage_ask = manage_ask;
        }

        //*********************************************************************
        public IActionResult Index()
        {
            ListUserAskViewModel list = this._manage_ask.ShopCardDetails();
            return View(list);
        }
        //*********************************************************************
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult IncludeAsk(int id,int page,string kw)
        {
            var item = this._manage_ask.DetailsFromDB(id);
            this._manage_ask.Include(item);

            return
                RedirectToAction

                    (
                        ControllerNavigateViewModel.Home_Index,
                        ControllerNavigateViewModel.Home,
                        new
                        {
                           
                            page = page,
                            kw = kw
                        }
                    );
            
        }
        //*********************************************************************
    }
}
