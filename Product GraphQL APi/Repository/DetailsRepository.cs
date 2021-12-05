using Microsoft.EntityFrameworkCore;
using Product_GraphQL_APi.Data.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_GraphQL_APi.Repository
{
    public class DetailsRepository
    {
        private readonly NORTHWNDContext _dbContext;

        public DetailsRepository(NORTHWNDContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<OrderDetail>> GetforOrder(int OrderId)
        {
            return await _dbContext.OrderDetails.Where(or => or.OrderId == OrderId).ToListAsync();
        }

        public async Task<ILookup<int, OrderDetail>> GetforOrders(IEnumerable<int> OrderId)
        {
            var details = await _dbContext.OrderDetails.Where(pr => OrderId.Contains(pr.OrderId)).ToListAsync();

            return details.ToLookup(d => d.OrderId);
        }
    }
}
