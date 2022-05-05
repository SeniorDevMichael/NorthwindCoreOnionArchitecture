using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthwindCore.Application.Interfaces.Repositories;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using NorthwindCore.Infrastructure.Context;
using NorthwindCore.Infrastructure.Repositories;
using NorthwindCore.Infrastructure.Repositories.Base;
using NorthwindCore.Infrastructure.UOW;
//using NorthwindCore.Infrastructure.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceRegistrator(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:Default"]);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            /*
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            */

            return services;
        }
    }
}
