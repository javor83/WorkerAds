using GCommon.Contracts;
using GCommon.ExtensionMethods;
using GCommon.Models;
using System.Configuration;

namespace GCommon.Services
{
    public class ManageAsk : IManageAsk
    {
        private const string USER_ASK_KEY = "USER_ASK_KEY";
        public const string SUMMARY_BASKET = "SUMMARY_BASKET";
        public const string ORDERED_ITEMS = "ORDERED_ITEMS";

        private IHttpContextAccessor _context = null;
        private IAdsPersonService _ads;
        private ILocalProfiles _profile = null;
        //******************************************************************************
        public ManageAsk(IHttpContextAccessor cn, IAdsPersonService service_ads,ILocalProfiles lp)
        {
            this._context = cn;
            this._ads = service_ads;
            this._profile = lp;
        }
       
       
        //******************************************************************************
        ManageAskViewModel IManageAsk.WhatToPost(IEnumerable<AdsPersonViewModel> in_card)
        {
             
            int[] ids = in_card.Select(x => x.DeclareWorkerFreeID).ToArray();



           var result = new ManageAskViewModel()
            {
                OrderDetails = string.Empty,
                Phone = string.Empty,
                ASPNETUSER_ID = this._profile.CurrentUserID(),
                AdvID = ids
            };
            return result;
        }
        //******************************************************************************
        async Task IManageAsk.IncludeAsOrder(ManageAskViewModel what_to_post)
        {
            await this._ads.PostOrder(what_to_post);
            (this as IManageAsk).Clear();
        }
        //******************************************************************************
        void IManageAsk.Remove(int adv_id)
        {
            List<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            var query = list.Where(x => x.DeclareWorkerFreeID == adv_id).First();
            if (query != null)
            {
                list.Remove(query);
                this._context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, list);
            }
        }
        


        //******************************************************************************
        AdsPersonViewModel IManageAsk.DetailsFromDB(int adv_id)
        {
            var result = this._ads.Details(adv_id);
            return result;
        }
        //******************************************************************************
        bool IManageAsk.Empty()
        {
            IEnumerable<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            bool result = list.Any() == false;
            return result;
        }
        //******************************************************************************
        int IManageAsk.Count()
        {
            IEnumerable<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            int result = list.Count();
            return result;
        }
        //******************************************************************************
        void IManageAsk.Clear()
        {
            List<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            list.Clear();
            this._context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, list);

        }
        //******************************************************************************
        IEnumerable<AdsPersonViewModel> IManageAsk.Print()
        {

            var result = (this as IManageAsk).Deserialize();

            return result;
        }
        //******************************************************************************
        List<AdsPersonViewModel> IManageAsk.Deserialize()
        {
            List<AdsPersonViewModel> result = null;
            bool exists_key = this._context.HttpContext.Session.Keys.Contains(ManageAsk.USER_ASK_KEY);
            if (exists_key)
            {
                result = this._context.HttpContext.Session.GetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY);

            }
            else
            {
                result = new List<AdsPersonViewModel>();
                this._context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, result);
            }


            return result;
        }
        //******************************************************************************
        void IManageAsk.Include(AdsPersonViewModel item)
        {
            bool exists_key = this._context.HttpContext.Session.Keys.Contains(ManageAsk.USER_ASK_KEY);
            if (exists_key)
            {
                List<AdsPersonViewModel> empty = this._context.HttpContext.Session.GetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY);
                if (empty.Any(x => x.DeclareWorkerFreeID == item.DeclareWorkerFreeID) == false)
                {
                    //не може да вмъкнеш два пъти една и съща обява
                    empty.Add(item);
                    this._context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, empty);
                }
                
            }
            else
            {
                List<AdsPersonViewModel> empty = new List<AdsPersonViewModel>();
                empty.Add(item);
                this._context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, empty);
            }
        }
        //******************************************************************************
    }
}
