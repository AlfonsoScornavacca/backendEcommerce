
using Business.Models.Request;
using Business.Models.Response;

namespace Business.Abstractions
{
    public interface IUserService
    {
        Task<UserResponse> Create(CreateUser user);
        Task<UserResponse> Update(int id, CreateUser user);
        Task<ICollection<UserResponse>> GetAll(UserRequest request);
        Task<UserResponse> GetById(int id);
        Task<UserResponse> GetByEmail(string email);
    }
}
