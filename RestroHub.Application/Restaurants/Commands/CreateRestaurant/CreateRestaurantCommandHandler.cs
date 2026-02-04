using MediatR;
using Microsoft.Extensions.Logging;
using RestroHub.Domain.Repositories;

namespace RestroHub.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
   IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand,int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Creating a new restaurant");
        
        var restaurnat = request.ToEntity();
        
        int id = await restaurantsRepository.Create(restaurnat);
        
        return id;
    }
}