using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Services;
using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Contracts.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
