using Microsoft.Extensions.DependencyInjection;
using RestroHub.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroHub.Application.Extensions
{
        public static class ServiceCollectionExtensions
        {
            public static void AddApplication(this IServiceCollection services)
            {
                services.AddScoped<IRestaurantsService, RestaurantsService>();

            }
        }
   
}
