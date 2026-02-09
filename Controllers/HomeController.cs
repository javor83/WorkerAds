using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Data;
using WebApplication6.Models;
using WebApplication6.Interfaces;

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
    }
}
