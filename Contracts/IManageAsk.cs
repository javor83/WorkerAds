using GCommon.Models;

namespace GCommon.Contracts
{
    public interface IManageAsk
    {
        void Include(AdsPersonViewModel item);

        List<AdsPersonViewModel> Deserialize();


        IEnumerable<AdsPersonViewModel> Print();
        ManageAskViewModel WhatToPost(IEnumerable<AdsPersonViewModel> ordered_items);

        Task IncludeAsOrder(ManageAskViewModel what_to_post);

        AdsPersonViewModel DetailsFromDB(int adv_id);

        bool Empty();
        int Count();

        void Clear();
    }
}
