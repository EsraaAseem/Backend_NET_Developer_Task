using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.Abstrations.Services;
using ProjectTaskManagement.Application.ExtensionService.Behaviors;

namespace ProjectTaskManagement.Application.ExtensionService
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatr().AddPipline().AddValidatorPipline();
           services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }
        //private static IServiceCollection AddMapping(this IServiceCollection services)
        //{
        //    var config = TypeAdapterConfig.GlobalSettings;
        //    services.AddScoped<IMapper, ServiceMapper>();

        //    config.Scan(Assembly.GetExecutingAssembly());
        //    services.AddSingleton(config);
        //    return services;
        //}
        private static IServiceCollection AddMediatr(this IServiceCollection services)
        {

            return services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        }

        private static IServiceCollection AddPipline(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        }
        private static IServiceCollection AddValidatorPipline(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        }
    }
}
