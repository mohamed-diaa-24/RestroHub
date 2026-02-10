using MediatR;
using Microsoft.Extensions.Logging;
using RestroHub.Domain.Entities;
using RestroHub.Domain.Exceptions;
using RestroHub.Domain.Repositories;

namespace RestroHub.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating Restaurant with id {@request.Id} with {@Restaurant}",request.Id,request);
        
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant),request.Id.ToString());



        request.MapTo(restaurant);
        
        await restaurantsRepository.SaveChangesAsync();
    }
}