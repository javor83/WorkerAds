using GCommon.Contracts;
using GCommon.Data;
using GCommon.ExtensionMethods;
using GCommon.Models;

namespace GCommon.Services
{
    public class ManageAsk(
        IHttpContextAccessor _http_context,
        MeisterContext _context,
        IAdsPersonService _ads, 
        ILocalProfiles _profile) : IManageAsk
    {
        private const string USER_ASK_KEY = "USER_ASK_KEY";
        public const string SUMMARY_BASKET = "SUMMARY_BASKET";
        public const string ORDERED_ITEMS = "ORDERED_ITEMS";

        //******************************************************************************
        /// <summary>
        /// какво да пратим като поръчка
        /// обекта в сесията, за кой потребител, телефон, детайлите
        /// </summary>
        /// <param name="in_card"></param>
        /// <returns></returns>
        ManageAskViewModel IManageAsk.WhatToPost(IEnumerable<AdsPersonViewModel> in_card)
        {

            int[] ids = in_card.Select(x => x.DeclareWorkerFreeID).ToArray();



            var result = new ManageAskViewModel()
            {
                OrderDetails = string.Empty,
                Phone = string.Empty,
                ASPNETUSER_ID = _profile.CurrentUserID(),
                AdvID = ids
            };
            return result;
        }
        //******************************************************************************
        /// <summary>
        /// изпращане на поръчаните услуги , телефон и детайли като поръчка в базата
        /// </summary>
        /// <param name="what_to_post"></param>
        /// <returns></returns>
        async Task IManageAsk.IncludeAsOrder(ManageAskViewModel what_to_post)
        {
            AspnetuserOrder item = new AspnetuserOrder()
            {
                OrderDate = DateTime.Now,
                AspnetusersId = what_to_post.ASPNETUSER_ID,
                Phone = what_to_post.Phone,
                OrderDetails = what_to_post.OrderDetails
            };
            _context.AspnetuserOrders.Add(item);
            foreach (var k in what_to_post.AdvID)
            {
                ItemsInOrder items_in_order = new ItemsInOrder()
                {

                    DeclareWorkerFreeId = k,
                    Order = item
                };
                _context.ItemsInOrders.Add(items_in_order);
            }

            await _context.SaveChangesAsync();
            (this as IManageAsk).Clear();
        }


        

        //******************************************************************************
        /// <summary>
        /// има ли поръчани услуги
        /// </summary>
        /// <returns></returns>
        bool IManageAsk.Empty()
        {
            IEnumerable<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            bool result = list.Any() == false;
            return result;
        }
        //******************************************************************************
        /// <summary>
        /// колко са поръчаните услуги
        /// </summary>
        /// <returns></returns>
        int IManageAsk.Count()
        {
            IEnumerable<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            int result = list.Count();
            return result;
        }
        //******************************************************************************
        /// <summary>
        /// изтриване след логаут преди финализиране на поръчката
        /// </summary>
        void IManageAsk.Clear()
        {
            List<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            list.Clear();
            _http_context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, list);

        }
        //******************************************************************************
        /// <summary>
        /// изтриване от сесията
        /// </summary>
        /// <param name="adv_id"></param>
        void IManageAsk.Remove(int adv_id)
        {
            List<AdsPersonViewModel> list = (this as IManageAsk).Deserialize();
            var query = list.Where(x => x.DeclareWorkerFreeID == adv_id).First();
            if (query != null)
            {
                list.Remove(query);
                _http_context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, list);
            }
        }
        //******************************************************************************
        /// <summary>
        /// вмъкване на услуга към сесията
        /// </summary>
        /// <param name="item"></param>
        void IManageAsk.Include(int adv_id)
        {
            AdsPersonViewModel details_adv = _ads.Details(adv_id);

            bool exists_key = _http_context.HttpContext.Session.Keys.Contains(ManageAsk.USER_ASK_KEY);
            if (exists_key)
            {
                List<AdsPersonViewModel> empty = _http_context.HttpContext.Session.GetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY);
                if (empty.Any(x => x.DeclareWorkerFreeID == details_adv.DeclareWorkerFreeID) == false)
                {
                    //не може да вмъкнеш два пъти една и съща обява
                    empty.Add(details_adv);
                    _http_context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, empty);
                }
                
            }
            else
            {
                List<AdsPersonViewModel> empty = new List<AdsPersonViewModel>();
                empty.Add(details_adv);
                _http_context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, empty);
            }
        }
        //******************************************************************************
        /// <summary>
        /// прочитане на сесията като списъчен обект
        /// </summary>
        /// <returns></returns>
        List<AdsPersonViewModel> IManageAsk.Deserialize()
        {
            List<AdsPersonViewModel> result = null;
            bool exists_key = _http_context.HttpContext.Session.Keys.Contains(ManageAsk.USER_ASK_KEY);
            if (exists_key)
            {
                result = _http_context.HttpContext.Session.GetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY);

            }
            else
            {
                result = new List<AdsPersonViewModel>();
                _http_context.HttpContext.Session.SetObject<List<AdsPersonViewModel>>(ManageAsk.USER_ASK_KEY, result);
            }


            return result;
        }
        //******************************************************************************
    }
}
