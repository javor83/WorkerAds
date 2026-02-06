using System;
using System.Collections.Generic;

namespace WebApplication6.DatabaseModels;

public partial class WorkerCapability
{
    public int Id { get; set; }

    public int? WorkerId { get; set; }

    public int? WorkCategoryId { get; set; }

    public decimal? Price { get; set; }

    public int? TaxWageId { get; set; }

    public virtual ICollection<DeclareWorkerFree> DeclareWorkerFrees { get; set; } = new List<DeclareWorkerFree>();

    public virtual TaxWage? TaxWage { get; set; }

    public virtual WorkCategory? WorkCategory { get; set; }

    public virtual Worker? Worker { get; set; }
}
