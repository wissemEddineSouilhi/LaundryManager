using LaundryManager.Application.Services;
using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Contracts.UnitOfWork;
using LaundryManager.Infrastructure.Data;
using LaundryManager.Infrastructure.Repositories;
using LaundryManager.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
