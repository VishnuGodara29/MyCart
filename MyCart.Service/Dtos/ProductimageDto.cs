using Microsoft.AspNetCore.Http;

namespace MyCart.Service.Dtos
{
    public class ProductimageDto
    {
        public IFormFile ImageUrl { get; set; }

        public int ProductId { get; set; }


    }
}
