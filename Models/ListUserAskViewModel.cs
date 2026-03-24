using System.Collections;
using System.Configuration;
using System.Text.Json;

namespace GCommon.Models
{
    public class ListUserAskViewModel:IEnumerable<AdsPersonViewModel>
    {
        private List<AdsPersonViewModel> data = null;

        public ListUserAskViewModel()
        {
            this.data = new List<AdsPersonViewModel>();
            this.Phone = string.Empty;
            this.OrderDetails = string.Empty;
        }

        public int Count()
        {
            return this.data.Count();
        }

        public AdsPersonViewModel Element(int i)
        {
            return this.data.ElementAt(i);
        }

        //****************************************************************
        public void AddRange(List<AdsPersonViewModel> list)
        {
            this.data.AddRange(list);
        }
        //****************************************************************
        public IEnumerator<AdsPersonViewModel> GetEnumerator()
        {
            return ((IEnumerable<AdsPersonViewModel>)data).GetEnumerator();
        }
        //****************************************************************
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)data).GetEnumerator();
        }

        //****************************************************************
        //записва се при потвърждение на поръчката
        public string Phone { get; set; }
        //****************************************************************
        //записва се при потвърждение на поръчката
        public string OrderDetails { get; set; }
        //****************************************************************



    }

   


   

    


}
