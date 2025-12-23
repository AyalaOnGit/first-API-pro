namespace Services;

using Entities;
using Repository;


public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository; 
    }

    public async Task<Order> AddOrder(Order oreder)
    {
        return await _orderRepository.AddOrder(oreder);
    }
    public async Task<Order> GetOrderById(int id)
    {
        return await _orderRepository.GetOrderById(id);
    }


}
