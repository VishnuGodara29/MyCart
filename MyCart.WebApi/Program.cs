using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyCarData;
using MyCart.Repository.CartProducts;
using MyCart.Repository.Carts;
using MyCart.Repository.Categorys;
using MyCart.Repository.GenericRepository;
using MyCart.Repository.GenericRepositorys;
using MyCart.Repository.Logins;
using MyCart.Repository.Orders;
using MyCart.Repository.Orders.OrderProducts;
using MyCart.Repository.Products;
using MyCart.Repository.Products.Images;
using MyCart.Repository.Users;
using MyCart.Service.CartProducts;
using MyCart.Service.Carts;
using MyCart.Service.Categorys;
using MyCart.Service.JWTSeriveses;
using MyCart.Service.Mapping;
using MyCart.Service.OrderProducts;
using MyCart.Service.OrderServices;
using MyCart.Service.Products;
using MyCart.Service.UserLogins;
using MyCart.Service.Users;
using System.Security.Claims;
using System.Text;


namespace MyCart.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DataContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("MYDefaultConnection")));




            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(typeof(MappingProfile)); // Add AutoMapper profile



            // Register repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IUserService, UserService>();  // Ensure UserService is registered
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();
            builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();

            builder.Services.AddScoped<IUserLoginRepository, UserLoginsRepository>();

            builder.Services.AddTransient<IJWTService, JWTService>();
            // Register services
            builder.Services.AddScoped<IUserLoginService, UserLoginService>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICartProductService, CartProductService>();
            builder.Services.AddScoped<IOrderProductService, OrderProductService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

.AddJwtBearer(options =>
{
    var issuer = builder.Configuration["JwtSettings:Issuer"];
    var audience = builder.Configuration["JwtSettings:Audience"];
    var secretKey = builder.Configuration["JwtSettings:SecretKey"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        RoleClaimType = ClaimTypes.Role
    };
});
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyCart API", Version = "v1" });

                // Add JWT Authentication to Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\nExample: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
            });




            var app = builder.Build();


            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}
