using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebApplication6.AppValidationErrorMessage;
using WebApplication6.Captions;
using WebApplication6.ExtensionMethods;

namespace WebApplication6.Models
{
    /// <summary>
    /// вмъкване на нова обява за работника
    /// </summary>
    public class AdvertisementToWorker
    {
       
        //**************************************************************************
        [Required(AllowEmptyStrings =false,ErrorMessage = valid_WorkerAd.Req_Field)]
        [Display(Name = text_WorkerAd.StartHour)]
        //в колко часа
        public required int? HourID { get; set; }
        //**************************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_WorkerAd.Req_Field)]
        [Display(Name = text_WorkerAd.AdvText)]
        public required string? AdvText { get; set; }
        //**************************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_WorkerAd.Req_Field)]
        [Display(Name = text_WorkerAd.StartDay)]
        public DateTime? WatchDate { get; set; }
        //**************************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_WorkerAd.Req_Field)]
        [Display(Name = text_WorkerAd.WorkCategory)]
        public required int? CapabilityID { get; set; }




        //**************************************************************************
        public required int? ID { get; set; }
        //**************************************************************************
        //за кого
        [Required]
        public required int? WorkerID { get; set; }
        //**************************************************************************
        //списък с часовете
        
        public required IEnumerable<WorkHour>? HourList { get; set; }
        //**************************************************************************
        
        public required IEnumerable<SelectWorkCapability>? CapalityList { get; set; }
        //**************************************************************************
        public required string WorkerFullName { get; set; }
        //**************************************************************************
        public static AdvertisementToWorker Empty(int id,string worker_name)
        {
            AdvertisementToWorker Empty = new AdvertisementToWorker()
            {
                ID = null,
                WorkerID = id,

                HourID = null,
                HourList = null,

                AdvText = string.Empty,
                WatchDate = DateTime.Today,

                CapabilityID = null,
                CapalityList = null,
                WorkerFullName = worker_name,




            };
            return Empty;
        }
        //**************************************************************************
        public IEnumerable<SelectListItem> ComboHours()
        {
            var query = from x in this.HourList
                        select
                         new SelectListItem()
                         {
                             Text = x.Hour.PrintableHour(x.Minute),
                             Value = x.ID.ToString()
                         };

            return query;
        }
        //**************************************************************************
        public IEnumerable<SelectListItem> ComboCapability()
        {
            var query = from x in this.CapalityList
                        select
                         new SelectListItem()
                         {
                             Text = x.Category.IncludeTaxPrint(x.TaxWage, Convert.ToDecimal(x.Price)),
                             Value = x.ID.ToString()
                         };

            return query;
        }

        //**************************************************************************


    }
}
