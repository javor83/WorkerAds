using System;
using System.Collections.Generic;

namespace GCommon.Data;

public partial class Worker
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public virtual ICollection<WorkerCapability> WorkerCapabilities { get; set; } = new List<WorkerCapability>();
}
