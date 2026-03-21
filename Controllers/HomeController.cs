using GCommon.Contracts;
using GCommon.Data;
using GCommon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace WebApplication6.Controllers
{
    
    public class HomeController : Controller
    {
     
        private IAdsPersonService _ads = null;
       
        //******************************************************************************************
        public HomeController(IAdsPersonService ads)
        {
            this._ads = ads;
           
        }
        //******************************************************************************************
        
        public IActionResult Index()
        {
          
            return View(this._ads.Read());
        }
        //******************************************************************************************
        public IActionResult Ads(int id)
        {
            AdsPersonViewModel? item = this._ads.Details(id);
            if (item != null)
            {
                return Json(new { x = item });
            }
            else
            {
                return NotFound();
            }
           
        }

        //******************************************************************************************
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            IActionResult result = null;
            switch (statusCode)
            {
                case 404:
                    result =  View("NotFound", null);
                    break;
                default:
                    UserFriendlyError view_model = new UserFriendlyError()
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Caption = $"General Exception error = {statusCode}"
                    };
                    result = View(view_model);
                    break;
            }
            return result;


        }
        //******************************************************************************************
    }
}
