using GraphQL.Types;
using Product_GraphQL_APi.Data.ModelDB;
using Product_GraphQL_APi.GraphQL.Types;
using Product_GraphQL_APi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_GraphQL_APi.GraphQL
{
    public class AppMutation : ObjectGraphType
    {
        //We Cover most essiential feature of Any API upon the Employee Table CRUD operation
        public AppMutation(EmployeeRepository employeeRepository)
        {
            FieldAsync<EmployeeType>(
                "CreateEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name="Employee" }),
                resolve: async context =>
                {
                    var newEmp = context.GetArgument<Employee>("employee");
                    return await context.TryAsyncResolve(async c => await employeeRepository.AddEmp(newEmp));
                }
                );

            FieldAsync<EmployeeType>(
                 "UpdateEmployee",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "Employee" }),
                 resolve: async context =>
                 {
                     var newEmp = context.GetArgument<Employee>("employee");
                     return await context.TryAsyncResolve(async c => await employeeRepository.UpdateEmp(newEmp));
                 }
                 );

           FieldAsync<StringGraphType>(
                 "DeleteEmployee",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "employeeId" }),
                 resolve:async context =>
                 {
                     var newEmp = context.GetArgument<int>("employeeId");
                     employeeRepository.DeleteEmp(newEmp);
                     return "We just Delete the item";
                 }
                 );

        }
    }
}
