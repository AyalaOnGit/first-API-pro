using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id) 
        {
            Order order = await _orderService.GetOrderById(id);
            if(order!= null)
            {
                return Ok(order);
            }
            return NoContent();
        }
  
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            Order createdOrder = await _orderService.AddOrder(order);
            if(createdOrder != null)
                return CreatedAtAction(nameof(Get), new{id = createdOrder.OrderId}, createdOrder);
            return BadRequest("ORDER DONT ACCEPT");
        }

    }
}
