
using DataAccess.Entities;

namespace DataAccess.Abstractions
{
    public interface IProductRepository
    {
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task Delete(int id);
        Task<Product> GetById(int id);
        Task<ICollection<Product>> GetAll(int pageSize, int pageNumber);
    }
}
