using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/controller")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<UserResponse>  Post([FromBody] CreateUser user)=>
            await _userService.Create(user);

        [HttpPut("{id}")]
        public async Task<UserResponse> Put(int id, [FromBody] CreateUser user)=>
            await _userService.Update(id, user);

        [HttpGet("{id}")]
        public async Task<UserResponse> Get(int id) =>
            await _userService.GetById(id);

        [HttpGet]
        public async Task<ICollection<UserResponse>> Get([FromQuery] UserRequest request) =>
            await _userService.GetAll(request);
    }
}
