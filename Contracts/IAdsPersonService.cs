using GCommon.Models;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за показване на публикуваните обяви
    /// </summary>
    public interface IAdsPersonService
    {
        IEnumerable<AdsPersonViewModel> Read();

        AdsPersonViewModel? Details(int adv_id);

    }
}
