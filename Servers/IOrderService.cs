using Entitys;
using Repository;

namespace Servers
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order oreder);
        Task<Order> GetOrderById(int id);
    }
}