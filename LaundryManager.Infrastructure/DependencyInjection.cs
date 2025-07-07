using LaundryManager.Domain.Contracts.UnitOfWork;
using LaundryManager.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Infrastructure.Repositories;

namespace LaundryManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
        {
            LaundaryDbContext.isMigration = false;
            services.AddDbContext<LaundaryDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommandStatusRepository, CommandStatusRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
