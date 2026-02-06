using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestroHub.Application.Restaurants.Commands.CreateRestaurant;
using RestroHub.Application.Restaurants.Commands.DeleteRestaurant;
using RestroHub.Application.Restaurants.Commands.UpdateRestaurant;
using RestroHub.Application.Restaurants.Queries.GetAllRestaurants;
using RestroHub.Application.Restaurants.Queries.GetRestaurantById;


namespace RestroHub.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await sender.Send( new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await sender.Send(new GetRestaurantByIdQuery(id));
            
            if (restaurant is null)
                return NotFound();

            return Ok(restaurant);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody]CreateRestaurantCommand command)
        {
            int id = await sender.Send(command);
            
            return CreatedAtAction(nameof(GetById), new {id},null);
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            var isDeleted = await sender.Send(new DeleteRestaurantCommand(id));
            
            if (isDeleted)
                return NoContent();

            return NotFound();
        }
        
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id,UpdateRestaurantCommand command)
        {
            command.Id = id;
            var isUpdated = await sender.Send(command);
            
            if (isUpdated)
                return NoContent();

            return NotFound();
        }
    }
}
