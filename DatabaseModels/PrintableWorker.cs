using System;
using System.Collections.Generic;

namespace WebApplication6.DatabaseModels;

public partial class PrintableWorker
{
    public int WorkerCapabilityId { get; set; }

    public int WorkerId { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string WorkCategory { get; set; } = null!;

    public decimal? Price { get; set; }

    public string Caption { get; set; } = null!;
}
