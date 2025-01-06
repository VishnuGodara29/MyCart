using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCart.Service.CartProducts;
using MyCart.Service.Dtos;

namespace MyCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {

        private readonly ICartProductService _cartProductService;

        public CartProductController(ICartProductService cartProductService)
        {
            _cartProductService = cartProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartProducts()
        {
            var cartProducts = await _cartProductService.GetAllCartProductsAsync();
            return Ok(cartProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartProductById(int id)
        {
            var cartProduct = await _cartProductService.GetCartProductByIdAsync(id);
            if (cartProduct == null)
            {
                return NotFound();
            }
            return Ok(cartProduct);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartProduct([FromBody] CartProductDto cartProductDto)
        {
            await _cartProductService.AddCartProductAsync(cartProductDto);
            return CreatedAtAction(nameof(GetCartProductById), new { id = cartProductDto.Id }, cartProductDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartProduct(int id, [FromBody] CartProductDto cartProductDto)
        {
            if (id != cartProductDto.Id)
            {
                return BadRequest("CartProduct ID mismatch");
            }

            await _cartProductService.UpdateCartProductAsync(id, cartProductDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartProduct(int id)
        {
            await _cartProductService.DeleteCartProductAsync(id);
            return NoContent();
        }
    }
}