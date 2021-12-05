using GraphQL.Types;
using Product_GraphQL_APi.Data.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_GraphQL_APi.GraphQL.Types
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Field(t => t.Title);
            Field(t => t.FirstName);
            Field(t => t.LastName);
            Field(t => t.Address);
            Field(t => t.BirthDate);
            Field(t => t.City);
            Field(t => t.PostalCode);
            Field(t => t.TitleOfCourtesy);
            Field(t => t.HomePhone);

        }
    }
}
