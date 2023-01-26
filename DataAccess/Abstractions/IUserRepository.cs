using DataAccess.Entities;

namespace DataAccess.Abstractions
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task Delete(int id);
        Task<User> GetById(int id);
        Task<ICollection<User>> GetAll(int pageSize, int pageNumber);
        Task<User>GetByEmail(string email);
    }
}
