using Business.Abstractions;
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
    public static class InfraestructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration) => services
            //Context
            .AddDbContext<DataAccess.DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Transient,
            ServiceLifetime.Scoped)
            //Repositories
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<IOrderRepository, OrderRepository>()
            //Services
            .AddTransient<IUserService, IUserService>()
            .AddTransient<IProductService, IProductService>()
            .AddTransient<IOrderService, IOrderService>();
    }
}
