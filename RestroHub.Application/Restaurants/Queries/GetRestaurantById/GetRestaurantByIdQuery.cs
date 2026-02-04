using MediatR;
using RestroHub.Application.Restaurants.Dto;

namespace RestroHub.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto?>
{
    public int Id { get; } = id;
}