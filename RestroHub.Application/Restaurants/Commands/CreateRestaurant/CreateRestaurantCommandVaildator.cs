using FluentValidation;

namespace RestroHub.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantreqValidator :AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];

    public CreateRestaurantreqValidator()
    {
        RuleFor(req => req.Name)
            .Length(3, 100);

        RuleFor(req => req.Category)
            .Must(validCategories.Contains)
            .WithMessage("Invalid category. Please choose from the valid categories.");

        RuleFor(req => req.ContactEmail)
            .EmailAddress()
            .WithMessage("Please provide a valid email address");

        RuleFor(req => req.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Please provide a valid postal code (XX-XXX).");

    }
}
