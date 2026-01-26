using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RestroHub.Application.Services;

namespace RestroHub.Application.Extensions
{
        public static class ServiceCollectionExtensions
        {
            public static void AddApplication(this IServiceCollection services)
            {
                services.AddScoped<IRestaurantsService, RestaurantsService>();
                services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
                .AddFluentValidationAutoValidation();
            }
        }
   
}
