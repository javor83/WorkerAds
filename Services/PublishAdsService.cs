using GCommon.Contracts;
using GCommon.Data;
using GCommon.ExtensionMethods;
using GCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCommon.Services
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
        async Task IPublishAdsService.UpdateAds(AdvertisementToWorkerViewModel sender)
        {
            DeclareWorkerFree decl = this._context.DeclareWorkerFrees.Find(sender.ID);
            if (decl != null)
            {
                decl.AdText = sender.AdvText;
                decl.WorkerCapabilityId = sender.CapabilityID;
                decl.HourId = sender.HourID;
                decl.WatchDate = sender.WatchDate;
                await this._context.SaveChangesAsync();
            }
        }
        //***************************************************************************
        bool IPublishAdsService.FindAds(int id)
        {
            var item = this._context.DeclareWorkerFrees.Find(id);
            return item != null;
        }
        //***************************************************************************
        AdvertisementToWorkerViewModel IPublishAdsService.DetailsAd(int id)
        {
            AdvertisementToWorkerViewModel result = (from decl_wfree in this._context.DeclareWorkerFrees

                                                     join work_hour in this._context.WorkStartHours
                                                     on decl_wfree.HourId equals work_hour.Id

                                                     join worker_capability in this._context.WorkerCapabilities
                                                     on decl_wfree.WorkerCapabilityId equals worker_capability.Id

                                                     join worker in this._context.Workers
                                                     on worker_capability.WorkerId equals worker.Id

                                                     where decl_wfree.Id == id
                                                     select new AdvertisementToWorkerViewModel()
                                                     {
                                                         AdvText = decl_wfree.AdText,
                                                         WatchDate = decl_wfree.WatchDate,
                                                         ID = id,
                                                         WorkerID = worker.Id,
                                                         HourID = work_hour.Id,
                                                         CapabilityID = worker_capability.Id,
                                                         CapalityList = null,
                                                         HourList = null,
                                                         WorkerFullName = worker.Fname.IncludeLastName(worker.Lname)
                                                     }).First();


            return result;

        }


        //***************************************************************************
        async Task IPublishAdsService.Insert(AdvertisementToWorkerViewModel sender)
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
        async Task IPublishAdsService.DeleteAds(int id)
        {
            DeclareWorkerFree dl = this._context.DeclareWorkerFrees.Find(id);
            if (dl != null)
            {
                this._context.DeclareWorkerFrees.Remove(dl);
                await this._context.SaveChangesAsync();
            }
        }

        //***************************************************************************
        WorkerAdsListViewModel IPublishAdsService.AdsForWorker(int worker_id)
        {
            IEnumerable<SelectPublishAdsItemViewModel> list = from worker in this._context.Workers

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
                                                              new SelectPublishAdsItemViewModel()
                                                              {
                                                                  ID = decl_worker_free.Id,
                                                                  AdvText = decl_worker_free.AdText,
                                                                  Hour = swork_hours.Shour,
                                                                  Minute = swork_hours.Sminute,
                                                                  CategoryName = work_category.Caption,
                                                                  TaxWage = tax_wage.Caption,
                                                                  Money = Convert.ToDecimal(worker_capability.Price),
                                                                  StartDay = Convert.ToDateTime(decl_worker_free.WatchDate),
                                                                  AdTitle = decl_worker_free.AdTitle

                                                              };

            var workerx = this._context.Workers.Find(worker_id);
            string full_name = workerx.Fname.IncludeLastName(workerx.Lname);

            var result = new WorkerAdsListViewModel()
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
