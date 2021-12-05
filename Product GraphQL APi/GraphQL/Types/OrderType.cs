using GraphQL.DataLoader;
using GraphQL.Types;
using Product_GraphQL_APi.Data.ModelDB;
using Product_GraphQL_APi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Product_GraphQL_APi.GraphQL.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(EmployeeRepository EmpRepository,
                        DetailsRepository detailsRepository,
                        IDataLoaderContextAccessor dataLoaderAccessor)
            
        {
            Field(t => t.OrderId);
            Field(t => t.OrderDate);
            Field(t => t.ShipAddress);
            Field(t => t.ShipCity);
            Field(t => t.Freight);

            //Get data of foreign keys
            //Relationship one to one between emp and order
            Field<EmployeeType>(
                "Employee",
                resolve: context => EmpRepository.GetheEmp(context.Source.EmployeeId)
                );

            //Get data of foreign keys
            //Relationship many to one between orderDetails and order
            Field<ListGraphType<ProductDetailsType>>(
                "OrderDetails",
                resolve: context =>
                {
                    var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, OrderDetail>(
                        "GetDetailsByOrderId", detailsRepository.GetforOrders);

                    return loader.LoadAsync(context.Source.OrderId);
                });

            


        }
    }
}
