using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestroHub.Application.Restaurants.Dto;
using RestroHub.Domain.Repositories;

namespace RestroHub.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,IMapper mapper) : IRequestHandler<GetAllRestaurantsQuery,IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");
        
        var restaurants = await restaurantsRepository.GetAllAsync();

        var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);


        return restaurantsDtos!;
    }
}