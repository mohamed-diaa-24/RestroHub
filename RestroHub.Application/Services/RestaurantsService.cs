using Microsoft.Extensions.Logging;
using RestroHub.Application.Dtos.Restaurants;
using RestroHub.Domain.Repositories;

namespace RestroHub.Application.Services;


internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger) : IRestaurantsService
{
 
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity);


        return restaurantsDtos!;
    }
    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting restaurant {id}");

        var restaurant = await restaurantsRepository.GetByIdAsync(id);
        var restaurantDto = RestaurantDto.FromEntity(restaurant);

        return restaurantDto;

    }
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation($"Creating a new restaurant");
        var restaurnat = CreateRestaurantDto.ToEntity(dto);
        int id = await restaurantsRepository.Create(restaurnat);
        return id;
    }

}
