using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCart.Service.Carts;
using MyCart.Service.Dtos;

namespace MyCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var carts = await _cartService.GetAllCartsAsync();
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(int id)
        {
            var cart = await _cartService.GetCartByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] CartDto cartDto)
        {
            await _cartService.AddCartAsync(cartDto);
            return CreatedAtAction(nameof(GetCartById), new { id = cartDto.Id }, cartDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] CartDto cartDto)
        {
            if (id != cartDto.Id)
            {
                return BadRequest("Cart ID mismatch");
            }

            await _cartService.UpdateCartAsync(id, cartDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _cartService.DeleteCartAsync(id);
            return NoContent();
        }
    }
}

