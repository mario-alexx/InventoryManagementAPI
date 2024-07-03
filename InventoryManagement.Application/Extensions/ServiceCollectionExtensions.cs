using InventoryManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using FluentValidation.AspNetCore;
using InventoryManagement.Application.IServices;


namespace InventoryManagement.Application.Extensions
{
    /// <summary>
    /// Extension methods for setting up application services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the application services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            //services.AddValidatorsFromAssemblyContaining
            services.AddFluentValidationClientsideAdapters();
            return services;
        }
    }
}
