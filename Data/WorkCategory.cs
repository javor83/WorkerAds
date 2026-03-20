using System;
using System.Collections.Generic;

namespace GCommon.Data;

public partial class WorkCategory
{
    public int Id { get; set; }

    public string Caption { get; set; } = null!;

    public virtual ICollection<WorkerCapability> WorkerCapabilities { get; set; } = new List<WorkerCapability>();
}
