using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCart.Domain.Products;
using MyCart.Repository.Products.Dtos;
using MyCart.Service.Dtos;
using MyCart.Service.Products;

namespace MyCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string ImageUrl = "https://localhost:7181/Documents";



        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
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
        [Authorize]
        [HttpPost("SearchProduct")]
        public async Task<ActionResult<List<ProductDTO>>>SearchProduct([FromForm]SearchProductDto? searchProductDto)
        {
          var data=  await _productService.SearchProductAsync(searchProductDto);
            if(data==null)
            {
                return NotFound("No data found");
            }
            return Ok(data);
        }
        [HttpPut("UploadProductImage {productId}")]
        public async Task<ActionResult> UploadProductImage(int productId,IFormFile Image)
        {
            var product= await _productService.GetProductByIdAsync(productId);
            if(product==null)
            {
                return NotFound($"Product not found on the Id= {productId}");
            }
            var fileExtension = Path.GetExtension(Image.FileName).ToLower();
            var filename = $"{Guid.NewGuid()}{fileExtension}";
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents", filename);
            using (var filestream = new FileStream(filepath, FileMode.Create))
            {
                await Image.CopyToAsync(filestream);
            }
            string imagePath = $"{ImageUrl}/{filename}";



             var image= await _productService.UploadImage(productId, imagePath);

            if (!image)
            {
                return BadRequest("Image not added");
            }
            return Ok("Image updated successfully..");
            


        }
        [HttpDelete("{productId}/image{imageId}")]
        public async Task<ActionResult> DeleteProductImage(int productId,int imageId)
        {
            var deleteImage= await _productService.RemoveImageAsync(productId,imageId);
            if (!deleteImage)
            {
                return BadRequest("Image not deleted");
            }
            return Ok("Image Deleted successfully...");
        }

    }
}
