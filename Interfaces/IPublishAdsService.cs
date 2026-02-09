using WebApplication6.Data;
using WebApplication6.ExtensionMethods;
using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    public interface IPublishAdsService
    {
        WorkerAdsList AdsForWorker(int worker_id);

        bool FindWorker(int worker_id);

    }

    

    



}
