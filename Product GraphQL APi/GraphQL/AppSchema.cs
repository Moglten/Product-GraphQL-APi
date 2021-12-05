using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Product_GraphQL_APi.GraphQL
{
    public class AppSchema:Schema
    {
        public AppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}
