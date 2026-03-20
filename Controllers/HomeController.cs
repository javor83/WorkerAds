using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GCommon.Data;

using Microsoft.AspNetCore.Authorization;
using GCommon.Models;
using GCommon.Contracts;

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
            return Json(new { x = id });
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
