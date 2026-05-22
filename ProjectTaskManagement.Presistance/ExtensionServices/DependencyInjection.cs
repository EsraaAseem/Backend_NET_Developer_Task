
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTaskManagement.Domain.IRepositories;
using ProjectTaskManagement.Domain.Models;
using ProjectTaskManagement.Presistance.Data;
using ProjectTaskManagement.Presistance.Repositories;

namespace ProjectTaskManagement.Presistance.ExtensionServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration)
                    .AddScoped<IProjectRepo, ProjectRepo>()
                    .AddScoped<ITaskItemRepo, TaskItemRepo>();
                    

            return services;
        }
        private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders()
             .AddEntityFrameworkStores<AppDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 2;

            });


            return services;
        }
    }
}
