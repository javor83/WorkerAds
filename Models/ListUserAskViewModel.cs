using System.Configuration;
using System.Text.Json;

namespace GCommon.Models
{
    public class ListUserAskViewModel
    {
        private List<AdsPersonViewModel> data = null;

        public ListUserAskViewModel()
        {
            this.data = new List<AdsPersonViewModel>();
            this.Phone = string.Empty;
            this.OrderDetails = string.Empty;
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
