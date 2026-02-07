using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace RestroHub.Application.Extensions
{
        public static class ServiceCollectionExtensions
        {
            public static void AddApplication(this IServiceCollection services,IConfiguration configuration)
            {
                var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
                
                services.AddMediatR(cfg=> cfg.
                    RegisterServicesFromAssembly(applicationAssembly)
                    .LicenseKey = configuration["MediatR-LicenseKey"]
                );
                
                services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();
            }
        }
}
