using Entities;
using Repository;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order oreder);
        Task<Order> GetOrderById(int id);
    }
}