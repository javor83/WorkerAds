using System;
using System.Collections.Generic;

namespace WebApplication6.DatabaseModels;

public partial class DeclareWorkerFree
{
    public int Id { get; set; }

    public int? HourId { get; set; }

    public int? WorkerCapabilityId { get; set; }

    public string? AdText { get; set; }

    public DateTime? WatchDate { get; set; }

    public virtual WorkStartHour? Hour { get; set; }

    public virtual WorkerCapability? WorkerCapability { get; set; }
}
