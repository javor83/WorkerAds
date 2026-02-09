

namespace WebApplication6.Data
{
    public partial class DayOfWeek
    {
        public int Id { get; set; }

        public string Caption { get; set; } = null!;

        public virtual ICollection<DeclareWorkerFree> DeclareWorkerFrees { get; set; } = new List<DeclareWorkerFree>();
    }
}
