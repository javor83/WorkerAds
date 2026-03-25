using GCommon.Models;

namespace GCommon.Contracts
{
    public interface IManageAsk
    {
        void Include(AdsPersonViewModel item);
        void Remove(int adv_id);
        AdsPersonViewModel DetailsFromDB(int adv_id);
        //-----------------------
        List<AdsPersonViewModel> Deserialize();


        IEnumerable<AdsPersonViewModel> Print();
        ManageAskViewModel WhatToPost(IEnumerable<AdsPersonViewModel> ordered_items);

        Task IncludeAsOrder(ManageAskViewModel what_to_post);

       

        bool Empty();
        int Count();

        void Clear();
    }
}
