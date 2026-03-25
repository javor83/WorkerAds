using System;
using System.Collections.Generic;

namespace GCommon.Data;

public partial class ItemsInOrder
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? DeclareWorkerFreeId { get; set; }

    public virtual DeclareWorkerFree? DeclareWorkerFree { get; set; }

    public virtual AspnetuserOrder? Order { get; set; }
}
