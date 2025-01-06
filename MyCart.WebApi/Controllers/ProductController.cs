using Microsoft.AspNetCore.Mvc;
using MyCart.Service.Dtos;
using MyCart.Service.Products;

namespace MyCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found." });
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest(new { message = "Invalid product data." });
            }
            var createdProduct = await _productService.CreateProductAsync(productDto);
            if (createdProduct == true)
            {
                return Ok("Created...");

            }
            else { return BadRequest("Someting went wrong"); }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, [FromBody] ProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest(new { message = "Invalid product data." });
            }

            var updatedProduct = await _productService.UpdateProductAsync(id, productDto);
            if (updatedProduct == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent(); // Return a NoContent response after deletion
        }
    }
}
