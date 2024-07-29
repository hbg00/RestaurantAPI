using RestaurantAPI.Data;

namespace RestaurantAPI.Seed
{
    public class RestaurantDbSeeder
    {
        private RestaurantDbContext _dbContext;
        public RestaurantDbSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
