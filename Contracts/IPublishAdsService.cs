using GCommon.Models;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за публикуване на обявите за работника
    /// </summary>
    public interface IPublishAdsService
    {
        /// <summary>
        /// обявите за работника
        /// </summary>
        /// <param name="worker_id">за кой работник</param>
        /// <returns></returns>
        WorkerAdsListViewModel AdsForWorker(int worker_id);

        bool FindWorker(int worker_id);

        Task Insert(AdvertisementToWorkerViewModel sender);

        Task DeleteAds(int id);

        bool FindAds(int id);

        AdvertisementToWorkerViewModel DetailsAd(int id);

        Task UpdateAds(AdvertisementToWorkerViewModel sender);

    }
}
