using WebApplication6.Data;
using WebApplication6.ExtensionMethods;
using WebApplication6.Interfaces;
using WebApplication6.Models;

namespace WebApplication6.Services
{
    public class PublishAdsService : IPublishAdsService
    {
        private readonly MeisterContext _context = null;
        //***************************************************************************
        public PublishAdsService(MeisterContext cn)
        {
            this._context = cn;
        }
        //***************************************************************************
        bool IPublishAdsService.FindWorker(int worker_id)
        {
            var query = this._context.Workers.Find(worker_id);
            bool result = query != null;
            return result;
        }
        //***************************************************************************
        async Task IPublishAdsService.Insert(AdvertisementToWorker sender)
        {
            DeclareWorkerFree decl_worker = new DeclareWorkerFree()
            {
                WatchDate = sender.WatchDate,
                AdText = sender.AdvText,
                HourId = sender.HourID,
                WorkerCapabilityId = sender.CapabilityID

            };
            this._context.DeclareWorkerFrees.Add(decl_worker);
            await this._context.SaveChangesAsync();
        }


        //***************************************************************************
        WorkerAdsList IPublishAdsService.AdsForWorker(int worker_id)
        {
            IEnumerable<SelectPublishAdsItem> list = from worker in this._context.Workers

                                                       join worker_capability in this._context.WorkerCapabilities
                                                       on worker.Id equals worker_capability.WorkerId

                                                       join tax_wage in this._context.TaxWages
                                                       on worker_capability.TaxWageId equals tax_wage.Id

                                                       join work_category in this._context.WorkCategories
                                                       on worker_capability.WorkCategoryId equals work_category.Id

                                                       join decl_worker_free in this._context.DeclareWorkerFrees
                                                       on worker_capability.Id equals decl_worker_free.WorkerCapabilityId

                                                       join swork_hours in this._context.WorkStartHours
                                                       on decl_worker_free.HourId equals swork_hours.Id

                                                       where worker.Id == worker_id

                                                       orderby
                                                             decl_worker_free.WatchDate ascending,
                                                             swork_hours.Shour ascending,
                                                             swork_hours.Sminute ascending


                                                       select
                                                       new SelectPublishAdsItem()
                                                       {
                                                           ID = decl_worker_free.Id,
                                                           AdvText = decl_worker_free.AdText,
                                                           Hour = swork_hours.Shour,
                                                           Minute = swork_hours.Sminute,
                                                           CategoryName = work_category.Caption,
                                                           TaxWage = tax_wage.Caption,
                                                           Money = Convert.ToDecimal(worker_capability.Price),
                                                           StartDay = Convert.ToDateTime(decl_worker_free.WatchDate)

                                                       };

            var workerx = this._context.Workers.Find(worker_id);
            string full_name = workerx.Fname.IncludeLastName(workerx.Lname);

            var result = new WorkerAdsList()
            {
                AdvList = list,
                WorkerFullName = full_name,
                WorkerID = worker_id
            };


            return result;


        }
        //***************************************************************************
    }
}
