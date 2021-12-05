using System;
using System.Collections.Generic;

#nullable disable

namespace Product_GraphQL_APi.Data.ModelDB
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
