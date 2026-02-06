using RestroHub.Application.Restaurants.Commands.CreateRestaurant;
using RestroHub.Application.Restaurants.Commands.UpdateRestaurant;
using RestroHub.Domain.Entities;

namespace RestroHub.Application.Restaurants;

public static class RestaurantExtensions
{
    public static Restaurant ToEntity(this CreateRestaurantCommand command) 
    { 
        if (command == null)
            return null;

        return new Restaurant
        {
            Name = command.Name,
            Description = command.Description,
            Category = command.Category,
            HasDelivery = command.HasDelivery,

            Address = new Address
            {
                City = command.City,
                PostalCode = command.PostalCode,
                Street = command.Street
            },

            ContactEmail = command.ContactEmail,
            ContactNumber = command.ContactNumber,
        }; 
    }  
    
    public static void MapTo(this UpdateRestaurantCommand command,Restaurant restaurant)
    {
        restaurant.Name = command.Name;
        restaurant.Description = command.Description;
        restaurant.HasDelivery = command.HasDelivery;
    }  
}