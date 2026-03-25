using GCommon.Models;

namespace GCommon.Contracts
{
    public interface IManageAsk
    {
        void Include(int adv_id);
        void Remove(int adv_id);
        
        //-----------------------
        List<AdsPersonViewModel> Deserialize();

       

        

        ManageAskViewModel WhatToPost(IEnumerable<AdsPersonViewModel> ordered_items);

        Task IncludeAsOrder(ManageAskViewModel what_to_post);

       


        bool Empty();
        int Count();

        void Clear();
    }
}
