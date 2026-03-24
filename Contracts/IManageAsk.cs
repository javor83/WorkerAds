using GCommon.Models;

namespace GCommon.Contracts
{
    public interface IManageAsk
    {
        void Include(AdsPersonViewModel item);

        List<AdsPersonViewModel> Deserialize();


        ListUserAskViewModel ShopCardDetails();


        

        AdsPersonViewModel DetailsFromDB(int adv_id);

        bool Empty();
        int Count();

        void Clear();
    }
}
