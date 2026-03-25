using GCommon.Contracts;
using GCommon.ExtensionAttributes;
using GCommon.Models;
using GCommon.Navigation;
using GCommon.Services;
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
            var ordered_items = this._manage_ask.Deserialize();
            ViewData[ManageAsk.ORDERED_ITEMS] = ordered_items;
            ManageAskViewModel to_post = this._manage_ask.WhatToPost(ordered_items);

            return View(to_post);
        }

      

      

        //*********************************************************************
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ManageAskViewModel sender)
        {
            var ordered_items = this._manage_ask.Deserialize();
            ViewData[ManageAsk.ORDERED_ITEMS] = ordered_items;

            

            if (ModelState.IsValid)
            {
                await this._manage_ask.IncludeAsOrder(sender);
                return RedirectToAction
                    (
                        ControllerNavigateViewModel.Home_Index,
                        ControllerNavigateViewModel.Home
                    );
            }
            else
            {
               return View(sender);
            }
           
        }
        //*********************************************************************
        //  //void IManageAsk.Remove(int adv_id)
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult RemoveAsk(int id)
        {
            this._manage_ask.Remove(id);
            return RedirectToAction
                (
                    ControllerNavigateViewModel.UserAsk_Index,
                    ControllerNavigateViewModel.UserAsk
                );
        }


        //*********************************************************************
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult IncludeAsk(int id,int page,string kw)
        {
           
            this._manage_ask.Include(id);

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
