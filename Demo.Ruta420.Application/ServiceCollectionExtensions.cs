using Demo.Ruta420.Application.Common;
using Demo.Ruta420.Application.Interfaces.Services;
using Demo.Ruta420.Application.Services;
using Demo.Ruta420.Application.Services.UserService;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Demo.Ruta420.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ISessionAsyncService, SessionAsyncService>();
            services.AddScoped<IUserAsyncService, UserAsyncService>();

            return services;
        }
    }
}