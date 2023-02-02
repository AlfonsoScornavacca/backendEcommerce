using Business.Models.Request;
using Business.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions
{
    public interface IAuthService
    {
        Task<string> Login(LoginRequest request);
        Task<UserResponse> Me(string email);

    }
}
