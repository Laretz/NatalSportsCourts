using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QuadrasNatal.Application.Commands.InsertBooking;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Application.Services;

namespace QuadrasNatal.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers();
               
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
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

