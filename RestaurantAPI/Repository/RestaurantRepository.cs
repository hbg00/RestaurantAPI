using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Entity;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Model;

namespace RestaurantAPI.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public RestaurantRepository(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _context.Restaurants
                .Include(r => r.Dishes)
                .Include(r => r.Address)
                .ToList();

            var restaurantsDto = _mapper.Map<List<RestaurantDto>>(restaurants);  

            return restaurantsDto;
        }

        public RestaurantDto GetById(int id) 
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id);

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }
    }
}
