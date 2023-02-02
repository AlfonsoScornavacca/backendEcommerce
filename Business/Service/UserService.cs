using Azure.Core;
using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using DataAccess.Abstractions;
using DataAccess.Entities;

namespace Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Create(CreateUser user)
        {
            var createUser = new User
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password, // Envolver password con funcion Hash
            };

            return Map(await _userRepository.Create(createUser));
        }

        public async Task<ICollection<UserResponse>> GetAll(UserRequest request)
        {
            var users = await _userRepository.GetAll(request.PageSize, request.PageNumber);
            return users.Select(user => Map(user)).ToList();
        }

        public async Task<UserResponse> GetById(int id) =>
            Map(await _userRepository.GetById(id));


        public async  Task<UserResponse> GetByEmailAndPassword(string email, string password)
        {
            var usersByEmail = await _userRepository.GetByEmailAndPassword(email, password);
            return Map(usersByEmail);
        }
           
        public async Task<UserResponse> Update(int id, CreateUser user)
        {
            var updateUser = new User
            {
                Id = id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
            };
            return Map(await _userRepository.Update(updateUser));
        }

        #region 

        private UserResponse? Map(User user) =>
            user != null
            ? new UserResponse
            {
                Name = user.Name,
                Email = user.Email,
                Id = user.Id,
            } 
            : null;
        #endregion
    }
}