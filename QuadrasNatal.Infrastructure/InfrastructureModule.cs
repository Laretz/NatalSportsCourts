using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuadrasNatal.Core.Repositories;
using QuadrasNatal.Infrastructure.Persistence;
using QuadrasNatal.Infrastructure.Persistence.Repositories;

namespace QuadrasNatal.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddData(configuration);

            return services;
        }
        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("QuadraNatalCs");
            services.AddDbContext<QuadrasNatalDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddScoped<IBookingRepository, BookingRepository>();
            return services;
        }
    }
}