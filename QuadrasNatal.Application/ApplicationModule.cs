using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QuadrasNatal.Application.Commands.InsertBooking;
using QuadrasNatal.Application.Models;

namespace QuadrasNatal.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();
               
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => 
                config.RegisterServicesFromAssemblyContaining<InsertBookingCommand>());

            services.AddTransient<IPipelineBehavior<InsertBookingCommand, ResultViewModel<int>>, ValidateInsertBookingCommand>();
              return services;
        }
        
        
    }
}

