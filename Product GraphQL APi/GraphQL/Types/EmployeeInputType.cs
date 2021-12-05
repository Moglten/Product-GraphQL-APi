using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_GraphQL_APi.GraphQL.Types
{
    public class EmployeeInputType : InputObjectGraphType
    {
        public EmployeeInputType()
        {
            Name = "EmployeeInput";
            Field<NonNullGraphType<StringGraphType>>("FirstName");
            Field<NonNullGraphType<StringGraphType>>("LastName");
            Field<NonNullGraphType<StringGraphType>>("Title");
            Field<NonNullGraphType<StringGraphType>>("City");
            Field<NonNullGraphType<StringGraphType>>("Address");
            Field<NonNullGraphType<StringGraphType>>("HomePhone");
            Field<NonNullGraphType<StringGraphType>>("PostalCode");
            Field<NonNullGraphType<StringGraphType>>("TitleOfCourtesy");
           
        }
    }
}
