using Microsoft.AspNetCore.Mvc;
using MyCart.Service.Dtos;
using MyCart.Service.OrderServices;

namespace MyCart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Get all orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get order by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync( id);
                if (order == null)
                    return NotFound("Order not found.");

                return Ok(order);
            }
          
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get orders by User ID
        //[HttpGet("user/{userId}")]
        //public async Task<IActionResult> GetOrdersByUserId(int userId)
        //{
        //    try
        //    {
        //        var orders = await _orderService.GetOrdersByUserIdAsync(userId);
        //        if (orders == null || orders.Count == 0)
        //            return NotFound("No orders found for the specified user.");

        //        return Ok(orders);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        // Create a new order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _orderService.CreateOrderAsync(orderDto);
                return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.Id }, orderDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update an existing order
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDto orderDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingOrder = await _orderService.GetOrderByIdAsync(id);
                if (existingOrder == null)
                    return NotFound("Order not found.");

                orderDto.Id = id; // Ensure the ID in DTO matches the route
                await _orderService.UpdateOrderAsync(orderDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Delete an order
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var existingOrder = await _orderService.GetOrderByIdAsync(id);
                if (existingOrder == null)
                    return NotFound("Order not found.");

                await _orderService.DeleteOrderAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
