using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCarData;

namespace MyCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplaodFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _dataContext;

        public UplaodFileController(IWebHostEnvironment webHostEnvironment, DataContext dataContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _dataContext = dataContext;
        }


        [HttpPost("api/productimage/UploadFile")]
        public IActionResult UploadFiles(List<IFormFile> files)
        {


            if (files.Count > 0)
            {
                var file = files[0];

                if (file != null && file.Length > 0)
                {
                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    var fileName = Guid.NewGuid().ToString().Replace("_", "") + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                }
            }
            return Ok("Upload Successful");
        }
    }
}
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MyCarData;
//using MyCart.Domain.Products;
//using System.IO;

//namespace MyCart.WebApi.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class UploadFileController : ControllerBase
//    {
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        private readonly DataContext _dataContext;

//        public UploadFileController(IWebHostEnvironment webHostEnvironment, DataContext dataContext)
//        {
//            _webHostEnvironment = webHostEnvironment;
//            _dataContext = dataContext;
//        }

//        [HttpPost("productimage/UploadFile")]
//        public IActionResult UploadFiles(List<IFormFile> files)
//        {
//            if (files.Count > 0)
//            {
//                var file = files[0];

//                if (file != null && file.Length > 0)
//                {
//                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
//                    var fileName = Guid.NewGuid().ToString().Replace("_", "") + Path.GetExtension(file.FileName);
//                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
//                    {
//                        file.CopyToAsync(fileStream);
//                    }

//                    // Optional: Save the file path and product information to the database
//                    var productImage = new ProductImages
//                    {
//                        ProductId = 1, // Example; should be replaced with actual product ID
//                        ImagePath = Path.Combine("Images", fileName)
//                    };
//                    _dataContext.ProductImages.Add(productImage);
//                    _dataContext.SaveChanges();
//                }
//            }
//            return Ok("Upload Successful");
//        }

//        //[HttpGet("productimage/GetByProductId/{productId}")]
//        //public IActionResult GetByProductId(int productId)
//        //{
//        //    // Query the database for the product image
//        //   // var productImage = _dataContext.ProductImages.FirstOrDefault(p => p.ProductId == productId);
//        //    if (productImage == null)
//        //    {
//        //        return NotFound("Product image not found");
//        //    }

//        //    // Generate full file path
//        //    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, productImage.ImagePath);
//        //    if (!System.IO.File.Exists(filePath))
//        //    {
//        //        return NotFound("Image file not found");
//        //    }

//        //    // Return the image file
//        //    var fileBytes = System.IO.File.ReadAllBytes(filePath);
//        //    return File(fileBytes, "image/jpeg"); // Adjust the MIME type as needed
//        //}
//    }
//}


