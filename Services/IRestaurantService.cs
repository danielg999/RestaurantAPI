using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        RestaurantDto GetById(int id);
        IEnumerable<RestaurantDto> GetAll();

        bool Delete(int id);

        bool Modify(int id, ModifyRestaurantDto dto);
    }
}