using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication6.Models;
using WebApplication6.Captions;
using WebApplication6.ExtensionMethods;
using WebApplication6.Interfaces;

namespace WebApplication6.Controllers
{
    public class WorkerController : Controller
    {
        private IWorkerService _worker = null;
        private ICapabilityService _service_capability = null;

        //**************************************************************************
        public WorkerController(IWorkerService sw, ICapabilityService service_capability)
        {
            this._worker = sw;
            this._service_capability = service_capability;
        }

        #region GET capability 
        //**************************************************************************
        /// <summary>
        ///какви способности има човекът
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Capability(int id)
        {


            string worker_name = this._service_capability.WorkerName(id);
            if (worker_name == null)
            {
                return NotFound();
            }
            else
            {
                ViewData[text_Label.SuccessApply] = string.Empty;

                if (TempData[text_Label.TempData_ok] != null)
                {
                    ViewData[text_Label.SuccessApply] = TempData[text_Label.TempData_ok] as string;
                }
                IEnumerable<SelectWorkCapability> list = this._service_capability.CapalityList(id);

                CapabilityDetails details = new CapabilityDetails()
                {
                    Actions = list,
                    WorkerName = worker_name,
                    WorkerID = id
                };
                return View(details);
            }


        }

        //**************************************************************************
        /// <summary>
        /// редакция на способност
        /// </summary>
        /// <param name="capability_id"></param>
        /// <returns></returns>
        public IActionResult EditCapability(int capability_id)
        {
            WorkCapability item = this._service_capability.EditCapability(capability_id);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
               
                return View(item);
            }

        }

        //**************************************************************************
        /// <summary>
        /// вмъкване на нова способност
        /// </summary>
        /// <param name="worker_id"></param>
        /// <returns></returns>
        public IActionResult EmptyCapability(int worker_id)
        {
            string worker_name = this._service_capability.WorkerName(worker_id);
            if (worker_name == null)
            {
                return NotFound();
            }
            else
            {

               

                WorkCapability item = new WorkCapability()
                {
                    WorkerID = worker_id,
                    WorkerName = worker_name,
                    ID = null,
                    Price = 0,
                    CategoryID = null,
                    TaxWageID = null,
                    ListTaxWage = this._service_capability.ComboWageTax(this._service_capability.GetWageTax()),
                    ListCategory = this._service_capability.ComboCategory(this._service_capability.GetCategory())

                };
                
                return View(item);
            }


        }




        #endregion

        #region POST capability

        /// <summary>
        /// редакция на способност
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCapability(WorkCapability sender)
        {
            sender.ListTaxWage = this._service_capability.ComboWageTax(this._service_capability.GetWageTax());
            sender.ListCategory = this._service_capability.ComboCategory(this._service_capability.GetCategory());


            if (ModelState.IsValid)
            {
                await this._service_capability.UpdateCapability(sender);

                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction
                   (
                       controller_navigate.Worker_Capability,
                       controller_navigate.Worker,
                       new { id = sender.WorkerID }

                   );
            }
            else
            {
                return View(sender);
            }

        }


        /// <summary>
        /// POST - изтриване на способност
        /// </summary>
        /// <param name="id"></param>
        /// <param name="worker_id"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCapability(int id,int worker_id)
        {
            await this._service_capability.DeleteCapabilty(id);
            return RedirectToAction
                   (
                       controller_navigate.Worker_Capability,
                       controller_navigate.Worker,
                       new { id = worker_id }

                   );
        }

        //**************************************************************************
        /// <summary>
        /// POST - нова способност на работника
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EmptyCapability(WorkCapability sender)
        {
            

            sender.ListTaxWage = this._service_capability.ComboWageTax(this._service_capability.GetWageTax());
            sender.ListCategory = this._service_capability.ComboCategory(this._service_capability.GetCategory());

            if (ModelState.IsValid)
            {
                await this._service_capability.InsertCapability(sender);

                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;

                return RedirectToAction
                    (
                        controller_navigate.Worker_Capability,
                        controller_navigate.Worker,
                        new { id = sender.WorkerID }

                    );
            }
            else
                return View(sender);

        }
        #endregion

        #region GET workers
        //**************************************************************************
        /// <summary>
        /// списък на работниците
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            ViewData[text_Label.SuccessApply] = string.Empty;

            if (TempData[text_Label.TempData_ok] != null)
            {
                ViewData[text_Label.SuccessApply] = TempData[text_Label.TempData_ok] as string;
            }

            return View(this._worker.Read());
        }
        //**************************************************************************
        /// <summary>
        /// нов работник
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            InsertWorker item = InsertWorker.Empty();
            return View(item);
        }
        //**************************************************************************
        /// <summary>
        /// редакция на работник
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            UpdateWorker item = this._worker.Find(id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return NotFound(id);
            }

        }
        #endregion

        #region POST workers
        

        //**************************************************************************
        /// <summary>
        /// POST - редакция на работника
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateWorker sender)
        {
            
            if (ModelState.IsValid)
            {
                await this._worker.Update(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction(controller_navigate.Worker_Index, controller_navigate.Worker);
            }
            else
                return View(sender);
                     
            
        }


        //**************************************************************************
        /// <summary>
        /// POST - изтрий работника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await this._worker.Delete(id);
            if (x)
            {
                return RedirectToAction(controller_navigate.Worker_Index, controller_navigate.Worker);
            }
            else
                return NotFound(id);

        }
        //**************************************************************************
        /// <summary>
        /// POST - създай работник
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsertWorker sender)
        {

            if (ModelState.IsValid)
            {
                await this._worker.Insert(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction(controller_navigate.Worker_Index, controller_navigate.Worker);
            }
            else
                return View(sender);

        }
        #endregion


        //**************************************************************************
    }
}
