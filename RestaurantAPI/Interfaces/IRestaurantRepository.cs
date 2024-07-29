using RestaurantAPI.Entity;

namespace RestaurantAPI.Interfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
    }
}
