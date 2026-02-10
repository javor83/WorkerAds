namespace WebApplication6.Models
{
    /// <summary>
    /// име на работника 
    /// и
    /// списък с обявите му
    /// </summary>
    public class WorkerAdsList
    {
        public string WorkerFullName { get; set; }

        public IEnumerable<SelectPublishAdsItem> AdvList { get; set; }

    }
}
