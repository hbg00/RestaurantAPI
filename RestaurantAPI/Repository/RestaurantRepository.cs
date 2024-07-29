using RestaurantAPI.Data;
using RestaurantAPI.Entity;
using RestaurantAPI.Interfaces;

namespace RestaurantAPI.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDbContext _context;
        public RestaurantRepository(RestaurantDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetById(int id) 
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
