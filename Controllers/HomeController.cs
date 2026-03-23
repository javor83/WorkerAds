using GCommon.Contracts;
using GCommon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult Index(int page = 1, string kw = "")
        {
            
            DisplayIndexViewModel page_count = this._ads.ReadAll(page,kw);
          
            return View(page_count);
        }
        //******************************************************************************************
        public IActionResult Ads(int id,int page=1,string kw="")
        {
            DisplayDetailsAdsViewModel key = new DisplayDetailsAdsViewModel()
            {
                Data = this._ads.Details(id),
                ApplyFilter = new FilterModel()
                {
                    CurrentPage = page,
                    Keyword = kw,
                    TotalPages = 1
                }
            };
          
            if (key.Data != null)
            {
                return View(key);
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
