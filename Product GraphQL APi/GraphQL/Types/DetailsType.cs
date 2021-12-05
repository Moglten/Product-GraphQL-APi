using GraphQL.Types;
using Product_GraphQL_APi.Data.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_GraphQL_APi.GraphQL.Types
{
    public class ProductDetailsType : ObjectGraphType<OrderDetail>
    {
        public ProductDetailsType()
        {
            Field(t => t.Quantity);
            Field(t => t.UnitPrice);
            Field(t => t.Discount);
        }
    }
}
