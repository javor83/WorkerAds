using GCommon.Models;
using GCommon.Services;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за показване на публикуваните обяви
    /// </summary>
    public interface IAdsPersonService
    {
      



        AdsPersonViewModel? Details(int adv_id);

       

        DisplayIndexViewModel ReadAll(int page, string keyword);
    }
}
