using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entity;
using RestaurantAPI.Interfaces;

namespace RestaurantAPI.Controllers
{

    [Route("api/{controller}")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            return Ok(_restaurantRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetById([FromRoute] int id) 
        {
            var restaurant = _restaurantRepository.GetById(id);
            
            if(restaurant == null)
                return NotFound();

            return restaurant;
        }
    }
}
