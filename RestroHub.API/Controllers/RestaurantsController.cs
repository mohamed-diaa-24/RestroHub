using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestroHub.Application.Restaurants.Commands.CreateRestaurant;
using RestroHub.Application.Restaurants.Commands.DeleteRestaurant;
using RestroHub.Application.Restaurants.Commands.UpdateRestaurant;
using RestroHub.Application.Restaurants.Dto;
using RestroHub.Application.Restaurants.Queries.GetAllRestaurants;
using RestroHub.Application.Restaurants.Queries.GetRestaurantById;


namespace RestroHub.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            var restaurants = await sender.Send( new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDto>> GetById([FromRoute] int id)
        {
            var restaurant = await sender.Send(new GetRestaurantByIdQuery(id));
            
            return Ok(restaurant);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateRestaurant([FromBody]CreateRestaurantCommand command)
        {
            int id = await sender.Send(command);
            
            return CreatedAtAction(nameof(GetById), new {id},null);
        }
        
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
          await sender.Send(new DeleteRestaurantCommand(id));
          
          return NoContent();
        }
        
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id,UpdateRestaurantCommand command)
        {
            command.Id = id;
            
            await sender.Send(command);
            
            return NoContent();
        }
    }
}
