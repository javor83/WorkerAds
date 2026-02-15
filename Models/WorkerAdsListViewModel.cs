using Microsoft.AspNetCore.Routing.Constraints;

namespace GCommon.Models
{
    /// <summary>
    /// име на работника 
    /// и
    /// списък с обявите му
    /// </summary>
    public class WorkerAdsListViewModel
    {
        public required string WorkerFullName { get; set; }

        public required int WorkerID { get; set; }

        public required IEnumerable<SelectPublishAdsItemViewModel> AdvList { get; set; }

    }
}
