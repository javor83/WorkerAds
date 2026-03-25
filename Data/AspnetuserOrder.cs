using System;
using System.Collections.Generic;

namespace GCommon.Data;

public partial class AspnetuserOrder
{
    public int OrderId { get; set; }

    public string AspnetusersId { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string OrderDetails { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public virtual AspNetUser Aspnetusers { get; set; } = null!;

    public virtual ICollection<ItemsInOrder> ItemsInOrders { get; set; } = new List<ItemsInOrder>();
}
