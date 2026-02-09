using WebApplication6.Data;
using WebApplication6.Interfaces;
using WebApplication6.Models;

namespace WebApplication6.Services
{
    public class PublishAds : IPublishAdsService
    {
        private readonly MeisterContext _context = null;
        public PublishAds(MeisterContext cn)
        {
            this._context = cn;
        }

        IEnumerable<SelectPublishAdsItem> IPublishAdsService.AdsForWorker(int worker_id)
        {
            IEnumerable<SelectPublishAdsItem> query = from worker in this._context.Workers


                                                      where worker.Id = worker_id
                                                      select
                                                      new SelectPublishAdsItem()
                                                      {

                                                      };


            return query;


        }
    }
}
