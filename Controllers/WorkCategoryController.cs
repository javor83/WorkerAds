using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication6.Models;
using WebApplication6.Captions;
using WebApplication6.ExtensionMethods;
using WebApplication6.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication6.Controllers
{
    /// <summary>
    /// контролер за категориите работа - вик/ел/мазилка и т.н
    /// </summary>
    [Authorize]
    public class WorkCategoryController : Controller
    {
        private IWorkCategoryService _category = null;
        //*****************************************************************************
        public WorkCategoryController(IWorkCategoryService ct)
        {
            this._category = ct;//ок
        }
       
       
        //*****************************************************************************
        #region get query
        
        public IActionResult Index()
        {
            
            ViewData[text_Label.SuccessApply] = string.Empty;

            if (TempData[text_Label.TempData_ok] != null)
            {
                ViewData[text_Label.SuccessApply] = TempData[text_Label.TempData_ok] as string;
            }
            return View(this._category.Read());
        }
        //*****************************************************************************
        public IActionResult Edit(int id)
        {

            if (this._category.Exists(id))
            {
                TaxCategory ct = this._category.To_DTO_WorkCategory(id);
                return View(ct);
            }
            else
                return NotFound();

        }
        //*****************************************************************************
        public IActionResult Create()
        {
            return View(TaxCategory.Empty());
        }
        #endregion

        #region post query
        //*****************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await this._category.Delete(id);
            return RedirectToAction(
                   controller_navigate.WorkCategory_Index,
                   controller_navigate.WorkCategory);
        }
        //*****************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaxCategory sender)
        {
            if (ModelState.IsValid)
            {
                await this._category.Update(sender);

                TempData[text_Label.TempData_ok] = text_Label
                    .SuccessApply;
                return RedirectToAction(
                      controller_navigate.WorkCategory_Index,
                      controller_navigate.WorkCategory);
            }
            else
                return View(sender);
        }
        //*****************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaxCategory sender)
        {
            if (ModelState.IsValid)
            {
                
                await this._category.Insert(sender);

                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction(
                    controller_navigate.WorkCategory_Index,
                    controller_navigate.WorkCategory);
            }
            else
                return View(sender);
        }
        #endregion

        //*****************************************************************************
    }
}
