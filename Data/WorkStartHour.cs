using System;
using System.Collections.Generic;

namespace GCommon.Data;

public partial class WorkStartHour
{
    public int Id { get; set; }

    public int Shour { get; set; }

    public int Sminute { get; set; }

    public virtual ICollection<DeclareWorkerFree> DeclareWorkerFrees { get; set; } = new List<DeclareWorkerFree>();
}
