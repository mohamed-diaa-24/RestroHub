using MediatR;
using RestroHub.Application.Restaurants.Dto;

namespace RestroHub.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}