using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication6.Models;
using WebApplication6.Captions;
using WebApplication6.ExtensionMethods;
using WebApplication6.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication6.Controllers
{
    /// <summary>
    /// контролер за начините на таксуване - ден/л.м/кубик и т.н
    /// </summary>
    [Authorize]
    public class WageTaxController : Controller
    {
        private readonly IWageTaxService _wage = null;
        //******************************************************************************
        public WageTaxController(IWageTaxService wage)
        {
            this._wage = wage;
        }

        #region get query
        //******************************************************************************
        /// <summary>
        /// преглед на наличните таксувания
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewData[text_Label.SuccessApply] = string.Empty;

            if (TempData[text_Label.TempData_ok] != null)
            {
                ViewData[text_Label.SuccessApply] = TempData[text_Label.TempData_ok] as string;
            }
            return View(this._wage.Read());
        }

        //*******************************************************************************************
        /// <summary>
        /// ново таксуване
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View(WageTax.Empty());
        }
        //******************************************************************************
        /// <summary>
        /// актуализация
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Update(int id)
        {
            bool exists = this._wage.Exists(id);
            if (exists)
            {
                var k = this._wage.To_DTO_WageTax(id);
                return View(k);
            }
            else
                return NotFound();

        }
        #endregion

        #region post query
        //*******************************************************************************************
        /// <summary>
        /// реална работа по таксуването
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WageTax sender)
        {
            if (ModelState.IsValid)
            {
                await this._wage.Create(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction(
                    nameof(WageTaxController.Index),
                    nameof(WageTaxController).Navigate()
                    );
            }
            else
                return View(sender);
        }
        //******************************************************************************
        /// <summary>
        /// изтриване на таксуване
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await this._wage.Delete(id);
            return RedirectToAction
                (
                nameof(WageTaxController.Index),
                nameof(WageTaxController).Navigate()
                );
        }
        //******************************************************************************
        /// <summary>
        /// работа по актуализацията
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(WageTax sender)
        {
            if (ModelState.IsValid)
            {
                await this._wage.Update(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction
                    (
                    nameof(WageTaxController.Index),
                    nameof(WageTaxController).Navigate()
                    );
            }
            else
                return View(sender);
        }
        #endregion

        //******************************************************************************
    }
}
