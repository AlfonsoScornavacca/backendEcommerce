using Business.Abstractions;
using Business.Service;
using DataAccess.Abstractions;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration) =>
            services
            //Context
            .AddDbContext<DataAccess.AppContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            //Repositories
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<IOrderRepository, OrderRepository>()
            //Services
            .AddTransient<IUserService, UserService>()
            .AddTransient<IProductService, ProductService>()
            .AddTransient<IOrderService, OrderService>()
            .AddTransient<IAuthService, AuthService>();
    }
}
