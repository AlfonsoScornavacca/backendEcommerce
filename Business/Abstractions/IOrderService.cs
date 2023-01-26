
using Business.Models.Request;
using Business.Models.Response;

namespace Business.Abstractions
{
    public interface IOrderService
    {
        Task<OrderResponse> Create(CreateOrder order);
        Task<OrderResponse> Update(int id, CreateOrder order);
        Task<ICollection<OrderResponse>> GetAll(OrderRequest request);
        Task<OrderResponse> GetById(int orderId);
    }
}
