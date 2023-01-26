using Business.Models.Request;
using Business.Models.Response;
using DataAccess.Abstractions;
using DataAccess.Entities;

namespace Business.Service
{
    public class ProductService : IProductRepository
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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ProductResponse>> GetAll(ProductRequest request)
        {
            var products = await _productRepository.GetAll(request.pageSize, request.pageNumber);
            return products.Select(product => Map(product)).ToList()
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

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
        #region
        private ProductResponse Map(Product product) =>
            new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        #endregion
    }
}
