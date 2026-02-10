using Microsoft.AspNetCore.Routing.Constraints;

namespace WebApplication6.Models
{
    /// <summary>
    /// име на работника 
    /// и
    /// списък с обявите му
    /// </summary>
    public class WorkerAdsList
    {
        public required string WorkerFullName { get; set; }

        public required int WorkerID { get; set; }

        public required IEnumerable<SelectPublishAdsItem> AdvList { get; set; }

    }
}
