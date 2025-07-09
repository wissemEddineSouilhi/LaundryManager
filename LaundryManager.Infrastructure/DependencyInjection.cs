using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Contracts.Security;
using LaundryManager.Domain.Contracts.UnitOfWork;
using LaundryManager.Infrastructure.Data;
using LaundryManager.Infrastructure.Repositories;
using LaundryManager.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LaundryManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            LaundaryDbContext.isMigration = false;
            services.AddDbContext<LaundaryDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommandStatusRepository, CommandStatusRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }

        public static IServiceCollection AddJWTServices(this IServiceCollection services, IConfiguration configuration)
        {
            var JwtKey = configuration.GetValue<string>("JwtKey");
            if (string.IsNullOrEmpty(JwtKey))
            {
                throw new ArgumentException("JWT Key is not configured in the application settings.");
            }
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey))
                };
            });
            return services;
        }


    }
}
