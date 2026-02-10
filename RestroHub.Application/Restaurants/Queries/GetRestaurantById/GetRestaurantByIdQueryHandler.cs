using MediatR;
using Microsoft.Extensions.Logging;
using RestroHub.Application.Restaurants.Dto;
using RestroHub.Domain.Entities;
using RestroHub.Domain.Exceptions;
using RestroHub.Domain.Repositories;

namespace RestroHub.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery,RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting restaurant {@restaurantId}",request.Id);

        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id)
              ?? throw new NotFoundException(nameof(Restaurant),request.Id.ToString());

        
        var restaurantDto = RestaurantDto.FromEntity(restaurant);

        return restaurantDto;
    }
}