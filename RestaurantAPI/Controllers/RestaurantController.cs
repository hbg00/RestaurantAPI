﻿using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Model;

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
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            return Ok(_restaurantRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> GetById([FromRoute] int id) 
        {
            var restaurant = _restaurantRepository.GetById(id);
            
            if(restaurant == null)
                return NotFound();

            return restaurant;
        }
    }
}
