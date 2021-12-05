using System;
using System.Collections.Generic;

#nullable disable

namespace Product_GraphQL_APi.Data.ModelDB
{
    public partial class CustomerAndSuppliersByCity
    {
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Relationship { get; set; }
    }
}
