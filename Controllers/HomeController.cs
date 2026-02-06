using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.DatabaseModels;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
     
        private IServiceAdsPerson _ads = null;
       
        //******************************************************************************************
        public HomeController(IServiceAdsPerson ads)
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
