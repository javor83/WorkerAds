using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GCommon.Data;

using Microsoft.AspNetCore.Authorization;
using GCommon.Models;
using GCommon.Contracts;

namespace WebApplication6.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
     
        private IAdsPersonService _ads = null;
       
        //******************************************************************************************
        public HomeController(IAdsPersonService ads)
        {
            this._ads = ads;
           
        }
        //******************************************************************************************
        [AllowAnonymous]
        public IActionResult Index()
        {
          
            return View(this._ads.Read());
        }
        //******************************************************************************************

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("NotFound", null);
                    break;
                default:
                    UserFriendlyError view_model = new UserFriendlyError()
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Caption = $"General Exception error = {statusCode}"
                    };
                    return View(view_model);
                    break;
            }


        }
        //******************************************************************************************
    }
}
