using System.Text.Json;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbShopContext _dbShopContext;
        public OrderRepository(DbShopContext dbShopContext)
        {
            _dbShopContext = dbShopContext;
        }
        public async Task<Order> AddOrder(Order oreder)
        {
            await _dbShopContext.Orders.AddAsync(oreder);
            await _dbShopContext.SaveChangesAsync();
            return await _dbShopContext.FindAsync<Order>(oreder.OrderId);
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _dbShopContext.FindAsync<Order>(id);
        }

    }
}
