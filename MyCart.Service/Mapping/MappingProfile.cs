using AutoMapper;
using MyCart.Domain.Carts;
using MyCart.Domain.Categorys;
using MyCart.Domain.Orders;
using MyCart.Domain.Products;
using MyCart.Domain.Users;
using MyCart.Service.Dtos;

namespace MyCart.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartProduct, CartProductDto>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, UserInDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap< CreateProductDto,Product > ();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
            CreateMap<UserLogin, UserLoginDto>().ReverseMap();
            

           
        }
    }
}
