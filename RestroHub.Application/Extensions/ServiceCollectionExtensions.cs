using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestroHub.Application.Restaurants.Dto;
using RestroHub.Domain.Entities;

namespace RestroHub.Application.Extensions
{
        public static class ServiceCollectionExtensions
        {
            public static void AddApplication(this IServiceCollection services,IConfiguration configuration)
            {
                var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;


                services.AddMediatR(cfg=> cfg.
                    RegisterServicesFromAssembly(applicationAssembly)
                    .LicenseKey = configuration["BundleMediatR-AutoMapperLicenseKey"]
                );


                services.AddAutoMapper(cfg =>
                {
                    cfg.LicenseKey = configuration["BundleMediatR-AutoMapperLicenseKey"];
                },typeof(ServiceCollectionExtensions).Assembly);
                
                services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();
            }
        }
}
