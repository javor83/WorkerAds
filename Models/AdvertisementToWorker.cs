using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    /// <summary>
    /// вмъкване на нова обява за работника
    /// </summary>
    public class AdvertisementToWorker
    {
        //**************************************************************************
        public required int? ID { get; set;}
        //**************************************************************************
        //за кого
        [Required]
        public required int? WorkerID { get; set; }
        //**************************************************************************
        [Required]
        //в колко часа
        public required int? HourID { get; set; }
        //**************************************************************************
        //списък с часовете
        [Required]
        public required IEnumerable<WorkHour> HourList { get; set; }
        //**************************************************************************
        [Required]
        public required string? AdvText { get; set; }
        //**************************************************************************
        [Required]
        public DateTime? WatchDate { get; set; }
        //**************************************************************************
        [Required]
        public required int? CapabilityID { get; set; }
        //**************************************************************************
        [Required]
        public required IEnumerable<SelectWorkCapability> CapalityList { get; set; }
        //**************************************************************************


        public static AdvertisementToWorker Empty(int worker_id)
        {
            AdvertisementToWorker result = new AdvertisementToWorker()
            {
                ID = worker_id,
                WorkerID = worker_id,

                HourID = null,
                HourList = null,

                AdvText = string.Empty,
                WatchDate = DateTime.Today,

                CapabilityID = null,
                CapalityList = null



            };
            return result;
        }

    }
}
