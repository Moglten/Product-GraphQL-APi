using Microsoft.EntityFrameworkCore;
using Product_GraphQL_APi.Data;
using Product_GraphQL_APi.Data.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_GraphQL_APi.Repository
{
    public class OrderRepository
    {
        private readonly NORTHWNDContext _dbContext;

        public OrderRepository(NORTHWNDContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOne(int orderId)
        {
            return await _dbContext.Orders.Where(o => o.OrderId == orderId).SingleOrDefaultAsync();
        }
    }
}
