namespace WebApplication6.Models
{
    public class WorkerAdsList
    {
        public string WorkerFullName { get; set; }

        public IEnumerable<SelectPublishAdsItem> AdvList { get; set; }

    }
}
