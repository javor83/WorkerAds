
namespace WebApplication6.Data
{
    public partial class TaxWage
    {
        public int Id { get; set; }

        public string Caption { get; set; } = null!;

        public virtual ICollection<WorkerCapability> WorkerCapabilities { get; set; } = new List<WorkerCapability>();
    }
}
