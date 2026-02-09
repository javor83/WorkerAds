using WebApplication6.Data;
using WebApplication6.ExtensionMethods;
using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    public interface IPublishAdsService
    {
        IEnumerable<SelectPublishAdsItem> AdsForWorker(int worker_id);

    }

    

    



}
