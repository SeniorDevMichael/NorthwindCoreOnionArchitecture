using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NorthwindCore.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationRegistrator(this IServiceCollection services)
        {
            var assm = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(assm);
            services.AddMediatR(assm);

            return services;
        }
    }
}
