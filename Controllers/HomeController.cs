using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GCommon.Data;

using Microsoft.AspNetCore.Authorization;
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
    }
}
