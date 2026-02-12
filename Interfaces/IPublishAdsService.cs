using System.ComponentModel.DataAnnotations;
using WebApplication6.Data;
using WebApplication6.ExtensionMethods;
using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    /// <summary>
    /// интерфейс за публикуване на обявите за работника
    /// </summary>
    public interface IPublishAdsService
    {
        WorkerAdsList AdsForWorker(int worker_id);

        bool FindWorker(int worker_id);

        Task Insert(AdvertisementToWorker sender);

        Task DeleteAds(int id);

        bool FindAds(int id);

        AdvertisementToWorker DetailsAd(int id);

        Task UpdateAds(AdvertisementToWorker sender);

    }








}
