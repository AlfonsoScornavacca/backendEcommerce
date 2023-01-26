using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using DataAccess.Abstractions;
using DataAccess.Entities;

namespace Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Create(CreateProduct product)
        {
            var entity = new Product
            {
                Name = product.Name,
                Price = product.Price,
            };
            return Map(await _productRepository.Create(entity));
        }
        public async Task<ICollection<ProductResponse>> GetAll(ProductRequest request)
        {
            var products = await _productRepository.GetAll(request.PageSize, request.PageNumber);
            return products.Select(product => Map(product)).ToList();
        }

        public async Task<ProductResponse> GetById(int productId) => Map(await _productRepository.GetById(productId));
        public async Task<ProductResponse> Update(int id, CreateProduct product)
        {

            var entity = new Product
            {   
                Id = id,
                Name = product.Name,
                Price = product.Price,
            };
            return Map(await _productRepository.Update(entity));
        }

        Task<UserResponse> IProductService.GetById(int userId)
        {
            throw new NotImplementedException();
        }
        #region
        private ProductResponse? Map(Product product) =>
            product != null
            ? new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            } : null;

        #endregion
    }
}
