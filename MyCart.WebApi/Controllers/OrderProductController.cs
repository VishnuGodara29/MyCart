using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCart.Service.Dtos;
using MyCart.Service.OrderProducts;

namespace MyCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductService _orderProductService;

        public OrderProductController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderProducts()
        {
            var orderProducts = await _orderProductService.GetAllOrderProductsAsync();
            return Ok(orderProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderProductById(int id)
        {
            var orderProduct = await _orderProductService.GetOrderProductByIdAsync(id);
            if (orderProduct == null)
            {
                return NotFound();
            }
            return Ok(orderProduct);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderProduct([FromBody] OrderProductDto orderProductDto)
        {
            await _orderProductService.AddOrderProductAsync(orderProductDto);
            return CreatedAtAction(nameof(GetOrderProductById), new { id = orderProductDto.Id }, orderProductDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderProduct(int id, [FromBody] OrderProductDto orderProductDto)
        {
            if (id != orderProductDto.Id)
            {
                return BadRequest("OrderProduct ID mismatch");
            }

            await _orderProductService.UpdateOrderProductAsync(id, orderProductDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderProduct(int id)
        {
            await _orderProductService.DeleteOrderProductAsync(id);
            return NoContent();
        }
    }
}
