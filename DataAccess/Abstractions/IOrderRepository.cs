
using DataAccess.Entities;

namespace DataAccess.Abstractions
{
    public interface IOrderRepository
    {
        Task<Order> Create(Order order);
        Task<Order> Update(Order order);
        Task<Order> GetById(int id);
        Task<ICollection<Order>> GetAll(int pageSize, int pageNumber);
    }
}
