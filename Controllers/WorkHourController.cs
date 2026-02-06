using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApplication6.Models;
using WebApplication6.Captions;


namespace WebApplication6.Controllers
{
    /// <summary>
    /// контролер за началните работни часове
    /// </summary>
    public class WorkHourController : Controller
    {

        private IServiceWorkHours _wh = null;
        //******************************************************************************
        public WorkHourController(IServiceWorkHours wh)
        {
            this._wh = wh;
        }

        

        #region get query
        //******************************************************************************
        /// <summary>
        /// четене на наличностите
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewData[text_Label.SuccessApply] = string.Empty;

            if (TempData[text_Label.TempData_ok] != null)
            {
                ViewData[text_Label.SuccessApply] = TempData[text_Label.TempData_ok] as string;
            }
            return View(this._wh.Read());
        }
        //******************************************************************************
        /// <summary>
        /// създаване 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            DTO_WorkHour data = DTO_WorkHour.Empty();

            return View(data);
        }
        //******************************************************************************
        /// <summary>
        /// редакция
        /// </summary>
        /// <param name="id"> за кого</param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            bool ok = this._wh.Exists(id);
            if (ok)
            {
                DTO_WorkHour key = this._wh.To_DTO_WorkHour(id);
                return View(key);
            }
            else
            {
                return NotFound();
            }
                
        }
        #endregion

        #region post query
        [HttpPost, ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Edit(DTO_WorkHour sender)
        {
            if (ModelState.IsValid)
            {
                await this._wh.Update(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction(controller_navigate.WorkHour_Index, controller_navigate.WorkHour);
            }
            else
            { 
                return View(sender);    
            }
        }


        //******************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DTO_WorkHour sender)
        {
            if (ModelState.IsValid)
            {
                await this._wh.Insert(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction(controller_navigate.WorkHour_Index, controller_navigate.WorkHour);
            }
            else
                return View(sender);
        }
        //******************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Delete(int id)
        {
            await this._wh.Delete(id);
            return RedirectToAction(controller_navigate.WorkHour_Index, controller_navigate.WorkHour);
        }
        #endregion







        //******************************************************************************

    }
}
