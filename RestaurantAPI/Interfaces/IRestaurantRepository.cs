using RestaurantAPI.Model;

namespace RestaurantAPI.Interfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
    }
}
