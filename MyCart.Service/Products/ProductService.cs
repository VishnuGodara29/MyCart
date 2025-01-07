using AutoMapper;
using MyCart.Domain.Products;
using MyCart.Repository.Products;
using MyCart.Repository.Products.Dtos;
using MyCart.Service.Dtos;

namespace MyCart.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // Get all products
        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        // Get product by ID
        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            return _mapper.Map<ProductDTO>(product);
        }

        // Get products by category ID
        public async Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        // Create a new product
        public async Task<bool> CreateProductAsync(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
           
            return true;
        }

        // Update an existing product
        public async Task<ProductDTO> UpdateProductAsync(int id, ProductDTO productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            _mapper.Map(productDto, product);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }

        // Delete a product
        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<ProductDTO>> SearchProductAsync(SearchProductDto searchProductDto)
        {
            var product = await _productRepository.SearchProductAsync(searchProductDto);
            return _mapper.Map<List<ProductDTO>>(product);
        }
    }
}
