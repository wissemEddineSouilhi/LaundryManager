using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;

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
