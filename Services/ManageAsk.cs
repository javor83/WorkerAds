using GCommon.Contracts;
using GCommon.ExtensionMethods;
using GCommon.Models;

namespace GCommon.Services
{
    public class ManageAsk : IManageAsk
    {
        private const string USER_ASK_KEY = "USER_ASK_KEY";
        public const string SUMMARY_BASKET = "SUMMARY_BASKET";

        private IHttpContextAccessor _context = null;
        private IAdsPersonService _ads;
        //******************************************************************************
        public ManageAsk(IHttpContextAccessor cn, IAdsPersonService service_ads)
        {
            this._context = cn;
            this._ads = service_ads;
        }
        //******************************************************************************
        void IManageAsk.Clear()
        {
            List<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            list.Clear();
            this._context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, list);

        }
        //******************************************************************************
        ListUserAskViewModel IManageAsk.ShopCardDetails()
        {
            ListUserAskViewModel result = new ListUserAskViewModel()
            {
                Phone = string.Empty,
                OrderDetails = string.Empty
            };
            var in_card = (this as IManageAsk).Deserialize();
            result.AddRange(in_card);

            return result;
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
            List<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            bool result = list.Count() == 0;
            return result;
        }
        //******************************************************************************
        int IManageAsk.Count()
        {
            List<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            int result = list.Count();
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
