using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto, int userId);
        RestaurantDto GetById(int id);
        IEnumerable<RestaurantDto> GetAll();

        void Delete(int id);

        void Modify(int id, ModifyRestaurantDto dto);
    }
}