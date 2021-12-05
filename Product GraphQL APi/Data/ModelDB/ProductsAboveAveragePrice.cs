using System;
using System.Collections.Generic;

#nullable disable

namespace Product_GraphQL_APi.Data.ModelDB
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
