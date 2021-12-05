using GraphQL.Types;
using Product_GraphQL_APi.Data;
using Product_GraphQL_APi.GraphQL.Types;
using Product_GraphQL_APi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_GraphQL_APi.GraphQL
{
    public class AppQuery : ObjectGraphType
    {
            public AppQuery(OrderRepository orderRepository,EmployeeRepository employeeRepository)
            {
                //Get of all element feature 
                Field<ListGraphType<OrderType>>(
                    "Orders",
                    resolve: context => orderRepository.GetAll()
                );

                //Argument feature of GraphQL to get Spacific element
                Field<OrderType>(
                    "Order",
                    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name="id"}),
                    resolve: context =>
                    {
                     
                        return orderRepository.GetOne(context.GetArgument<int>("id"));
                    }
                    );


                Field<ListGraphType<EmployeeType>>(
                    "Employees",
                    resolve: context => employeeRepository.GetAll()
                    );


                Field<EmployeeType>(
                    "Employee",
                    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                    resolve: context =>
                    {
                        return employeeRepository.GetOne(context.GetArgument<int>("id"));
                    });

            }
        
    }
}
