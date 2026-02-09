namespace WebApplication6.Data
{
    public partial class PrintableAd
    {
        public int WorkerCapabilityId { get; set; }

        public int WorkerId { get; set; }

        public string Fname { get; set; } = null!;

        public string Lname { get; set; } = null!;

        public string WorkCategory { get; set; } = null!;

        public decimal? Price { get; set; }

        public string Caption { get; set; } = null!;

        public string DayName { get; set; } = null!;

        public string? StartTime { get; set; }

        public string? AdText { get; set; }
    }
}
