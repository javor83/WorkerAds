using GCommon.Captions;
using GCommon.ValidationMessage;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text.Json;

namespace GCommon.Models
{



    public class ListUserAskViewModel : IEnumerable<AdsPersonViewModel>
    {
        public List<AdsPersonViewModel> data { get; set; } = new List<AdsPersonViewModel>();
        //****************************************************************


        public bool Any()
        {
            return this.data.Any();
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



    }












}
