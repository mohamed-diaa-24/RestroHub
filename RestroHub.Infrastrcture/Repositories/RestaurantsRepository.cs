using Microsoft.EntityFrameworkCore;
using RestroHub.Domain.Entities;
using RestroHub.Domain.Repositories;
using RestroHub.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroHub.Infrastructure.Repositories
{
    internal class RestaurantsRepository(AppDbContext dbContext)
        :IRestaurantsRepository
    {
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            var restaurant = await dbContext.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(x => x.Id == id);

            return restaurant;
        }
    }
}
