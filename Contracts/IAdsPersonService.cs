using GCommon.Models;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за показване на публикуваните обяви
    /// </summary>
    public interface IAdsPersonService
    {
        IEnumerable<AdsPersonViewModel> ReadAll();

        AdsPersonViewModel? Details(int adv_id);

        int PageCount();

        IEnumerable<AdsPersonViewModel> PagedSet(FilterModel filter);
    }
}
