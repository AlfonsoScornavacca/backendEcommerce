using Business.Abstractions;
using Business.Models.Request;
using Business.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class AuthService : IAuthService
    {

        private readonly IUserService _usersService;
        private readonly IConfiguration _configuration;
        public AuthService(IUserService usersService, IConfiguration configuration)
        {
            _usersService = usersService;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginRequest request)
        {
            var email = request.Email?.Trim() ?? "";
            //Obtener Hash de request.Password
            var user = await _usersService.GetByEmail(email);

            if (user != null)
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  // identificador de token
					new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()), // hora a la que fue emitido
					new Claim("Id", user.Id.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Email", user.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    expires: DateTime.UtcNow.AddMinutes(10),
                    claims: claims,
                    signingCredentials: signIn);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null;
        }

        public async Task<UserResponse> Me(string email) =>
            await _usersService.GetByEmail(email);

    }
}
