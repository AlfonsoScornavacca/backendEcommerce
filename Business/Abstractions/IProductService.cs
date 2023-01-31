
using Business.Models.Request;
using Business.Models.Response;

namespace Business.Abstractions
{
    public interface IProductService
    {
        Task<ProductResponse> Create(CreateProduct product);
        Task<ProductResponse> Update(int id, CreateProduct product);
        Task<ICollection<ProductResponse>> GetAll(ProductRequest request);
        Task<ProductResponse> GetById(int Id);
        Task<ICollection<ProductResponse>> Search(ProductSearchRequest request);
    }
}
