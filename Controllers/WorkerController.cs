using GCommon.Captions;
using GCommon.Contracts;
using GCommon.ExtensionAttributes;
using GCommon.Models;
using GCommon.Navigation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication6.Controllers
{

    [AuthorizeAdmin()]
    public class WorkerController
        (
            IWorkerService service_worker,
            ICapabilityService service_capability,
            IPublishAdsService service_publish,
            IWorkHoursService service_hours
        ) : Controller
    {
        



        #region GET ADS
        //**************************************************************************
        /// <summary>
        /// какви са обявите от този работник
        /// </summary>
        /// <param name="id">номер на работника</param>
        /// <returns></returns>
        public IActionResult Ads(int id)
        {
            
            var ok = service_publish.FindWorker(id);
            if (ok)
            {
                ViewData[text_Label.SuccessApply] = string.Empty;

                if (TempData[text_Label.TempData_ok] != null)
                {
                    ViewData[text_Label.SuccessApply] = TempData[text_Label.TempData_ok] as string;
                }

                var list = service_publish.AdsForWorker(id);
                return View(list);
            }
            else
                return NotFound();
        }
        //**************************************************************************
        /// <summary>
        /// нова обява за този работник
        /// </summary>
        /// <param name="id">номер на работника</param>
        /// <returns></returns>
        public IActionResult EmptyAds(int id)
        {
            string worker_name = service_capability.WorkerName(id);
            if (worker_name == null)
            {
                return NotFound();
            }
            else
            {
                AdvertisementToWorkerViewModel Empty = AdvertisementToWorkerViewModel.Empty(id, worker_name);
                Empty.HourList = service_hours.Read();
                Empty.CapalityList = service_capability.CapalityList(id);
                return View(Empty);
            }


               
        }
        //**************************************************************************
        /// <summary>
        /// какви са детайлите за тази обява ID
        /// </summary>
        /// <param name="id">номер на обявата</param>
        /// <returns></returns>
        public IActionResult EditAds(int id)
        {
            bool find_service = service_publish.FindAds(id);
            if (find_service)
            {
               

                AdvertisementToWorkerViewModel Empty = service_publish.DetailsAd(id);
                Empty.HourList = service_hours.Read();
                Empty.CapalityList = service_capability.CapalityList(Convert.ToInt32(Empty.WorkerID));
                return View(Empty);
            }
            else
            {
                return NotFound();
            }
        }



        //**************************************************************************
        #endregion

        #region POST ADS
        /// <summary>
        /// актуализация на обява
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAds(AdvertisementToWorkerViewModel sender)
        {
            sender.HourList = service_hours.Read();
            sender.CapalityList = service_capability.CapalityList(Convert.ToInt32(sender.WorkerID));

            if (ModelState.IsValid)
            {

                await service_publish.UpdateAds(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction
                  (
                      ControllerNavigateViewModel.Worker_Ads,
                      ControllerNavigateViewModel.Worker,
                      new { id = sender.WorkerID }
                  );
            }
            else
            {
                return View(sender);
            }

        }
        //**************************************************************************
        /// <summary>
        /// изтриване на обява
        /// </summary>
        /// <param name="id">номер на обявата</param>
        /// <param name="worker_id">към кой работник да се върнем</param>
        /// <returns></returns>
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAds(int id,int worker_id)
        {
            await service_publish.DeleteAds(id);
            return RedirectToAction
                (
                  ControllerNavigateViewModel.Worker_Ads,
                  ControllerNavigateViewModel.Worker,
                  new { id = worker_id }
                );
        }
        //**************************************************************************
        /// <summary>
        /// публикуване на нова обява
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EmptyAds(AdvertisementToWorkerViewModel sender)
        {
            sender.HourList = service_hours.Read();
            sender.CapalityList = service_capability.CapalityList(sender.WorkerID.Value);

            if (ModelState.IsValid)
            {
                
                await service_publish.Insert(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction
                    (
                        ControllerNavigateViewModel.Worker_Ads,
                        ControllerNavigateViewModel.Worker,
                        new { id = sender.WorkerID }
                    );
            }
            else
            {
                return View(sender);
            }
        }
        #endregion

        #region GET capability 
        //**************************************************************************
        /// <summary>
        ///какви способности има човекът
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Capability(int id)
        {

            
            string worker_name = service_capability.WorkerName(id);
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
                IEnumerable<SelectWorkCapabilityViewModel> list = service_capability.CapalityList(id);

                CapabilityDetailsViewModel details = new CapabilityDetailsViewModel()
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
            WorkCapabilityViewModel item = service_capability.EditCapability(capability_id);

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
            string worker_name = service_capability.WorkerName(worker_id);
            if (worker_name == null)
            {
                return NotFound();
            }
            else
            {

               

                WorkCapabilityViewModel item = new WorkCapabilityViewModel()
                {
                    WorkerID = worker_id,
                    WorkerName = worker_name,
                    ID = null,
                    Price = 0,
                    CategoryID = null,
                    TaxWageID = null,
                    ListTaxWage = service_capability.ComboWageTax(service_capability.GetWageTax()),
                    ListCategory = service_capability.ComboCategory(service_capability.GetCategory())

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
        public async Task<IActionResult> EditCapability(WorkCapabilityViewModel sender)
        {
            sender.ListTaxWage = service_capability.ComboWageTax(service_capability.GetWageTax());
            sender.ListCategory = service_capability.ComboCategory(service_capability.GetCategory());


            if (ModelState.IsValid)
            {
                await service_capability.UpdateCapability(sender);

                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction
                   (
                       ControllerNavigateViewModel.Worker_Capability,
                       ControllerNavigateViewModel.Worker,
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
            await service_capability.DeleteCapabilty(id);
            return RedirectToAction
                   (
                       ControllerNavigateViewModel.Worker_Capability,
                       ControllerNavigateViewModel.Worker,
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
        public async Task<IActionResult> EmptyCapability(WorkCapabilityViewModel sender)
        {
            

            sender.ListTaxWage = service_capability.ComboWageTax(service_capability.GetWageTax());
            sender.ListCategory = service_capability.ComboCategory(service_capability.GetCategory());

            if (ModelState.IsValid)
            {
                await service_capability.InsertCapability(sender);

                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;

                return RedirectToAction
                    (
                        ControllerNavigateViewModel.Worker_Capability,
                        ControllerNavigateViewModel.Worker,
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

            return View(service_worker.Read());
        }
        

        //**************************************************************************
        /// <summary>
        /// нов работник
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            InsertWorkerViewModel item = InsertWorkerViewModel.Empty();
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
            
            UpdateWorkerViewModel item = service_worker.Find(id);
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
        public async Task<IActionResult> Edit(UpdateWorkerViewModel sender)
        {
            
            if (ModelState.IsValid)
            {
                await service_worker.Update(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction(ControllerNavigateViewModel.Worker_Index, ControllerNavigateViewModel.Worker);
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
            var x = await service_worker.Delete(id);
            if (x)
            {
                return RedirectToAction(ControllerNavigateViewModel.Worker_Index, ControllerNavigateViewModel.Worker);
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
        public async Task<IActionResult> Create(InsertWorkerViewModel sender)
        {

            if (ModelState.IsValid)
            {
                await service_worker.Insert(sender);
                TempData[text_Label.TempData_ok] = text_Label.SuccessApply;
                return RedirectToAction(ControllerNavigateViewModel.Worker_Index, ControllerNavigateViewModel.Worker);
            }
            else
                return View(sender);

        }
        #endregion

    }
}
