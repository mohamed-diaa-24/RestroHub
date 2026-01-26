using RestroHub.Domain.Entities;

namespace RestroHub.Application.Dtos.Restaurants
{
    public class CreateRestaurantDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }

        public string? ContactEmail { get; set; } 
        public string? ContactNumber { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }


        public static Restaurant ToEntity(CreateRestaurantDto createRestaurantDto)
        {
            if (createRestaurantDto == null)
                return null;

            return new Restaurant 
            { 
                Name = createRestaurantDto.Name,
                Description = createRestaurantDto.Description,
                Category = createRestaurantDto.Category,
                HasDelivery = createRestaurantDto.HasDelivery,

                Address = new Address
                {
                    City = createRestaurantDto.City,
                    PostalCode = createRestaurantDto.PostalCode,
                    Street = createRestaurantDto.Street
                },

                ContactEmail = createRestaurantDto.ContactEmail,
                ContactNumber = createRestaurantDto.ContactNumber,
            };

        }
    }
}
