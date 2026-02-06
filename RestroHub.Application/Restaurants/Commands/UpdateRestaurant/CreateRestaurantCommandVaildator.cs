using FluentValidation;
using RestroHub.Application.Restaurants.Commands.CreateRestaurant;

namespace RestroHub.Application.Restaurants.Commands.UpdateRestaurant;

public class CreateRestaurantreqValidator :AbstractValidator<UpdateRestaurantCommand>
{

    public CreateRestaurantreqValidator()
    {
        RuleFor(req => req.Name)
            .Length(3, 100);

       

    }
}
