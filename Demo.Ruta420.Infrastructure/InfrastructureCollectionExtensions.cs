using Demo.Ruta420.Application.Interfaces;
using Demo.Ruta420.Infrastructure.Persistence;
using Demo.Ruta420.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Ruta420.Infrastructure
{
    public static class InfrastructureCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var cnn = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<RutaDbContext>(opt => opt.UseSqlServer(cnn, b => b.MigrationsAssembly(typeof(RutaDbContext).Assembly.FullName)))
                .AddScoped<IRutaDbContext>(provider => provider.GetRequiredService<RutaDbContext>())
                .AddTransient(typeof(IRepositoryAsyncArdalis<>), typeof(RepositoryAsyncArdalis<>));

            return services;
        }
    }
}