using GCommon.Captions;
using GCommon.Contracts;
using GCommon.Models;
using GCommon.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApplication6.Controllers
{
    
    public class HomeController : Controller
    {
     
        private IAdsPersonService _ads = null;
        
        private IManageAsk manage_ask = null;
        //******************************************************************************************
        public HomeController(IAdsPersonService ads, IManageAsk manage_ask)
        {
            this._ads = ads;
            this.manage_ask = manage_ask;
        }
        //******************************************************************************************

        public IActionResult Index(int page = 1, string kw = "")
        {
            
            ViewData[text_Label.SuccessApply] = string.Empty;

            if (TempData[text_Label.TempData_ok] != null)
            {
                ViewData[text_Label.SuccessApply] = TempData[text_Label.TempData_ok] as string;
            }
             
            ViewData[ManageAsk.SUMMARY_BASKET] = new SummaryManageAsk()
            {
                EmptyBasket = this.manage_ask.Empty(),
                BasketCount = this.manage_ask.Count()
            };
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
