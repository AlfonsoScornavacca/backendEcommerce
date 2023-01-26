using Business.Models.Response;
using DataAccess.Abstractions;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class ProductService : IProductRepository
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetAll(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product product)
        {
            throw new NotImplementedException();
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
