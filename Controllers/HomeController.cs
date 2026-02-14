using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Data;
using WebApplication6.Models;
using WebApplication6.Interfaces;
using Microsoft.AspNetCore.Authorization;

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
