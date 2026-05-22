
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTaskManagement.Application.Abstrations.IServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Infrastructure.AuthServices;

namespace ProjectTaskManagement.Infrastructure.ExtensionServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
            .AddScoped<IJWTService, JWTService>();
            services.Configure<JWTSettings>(configuration.GetSection("JWT"));

            return services;
        }

    }
}
