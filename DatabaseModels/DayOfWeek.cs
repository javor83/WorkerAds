using System;
using System.Collections.Generic;

namespace WebApplication6.DatabaseModels;

public partial class DayOfWeek
{
    public int Id { get; set; }

    public string Caption { get; set; } = null!;

    public virtual ICollection<DeclareWorkerFree> DeclareWorkerFrees { get; set; } = new List<DeclareWorkerFree>();
}
