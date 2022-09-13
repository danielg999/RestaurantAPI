using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        RestaurantDto GetById(int id);
        PageResult<RestaurantDto> GetAll(RestaurantQuery query);

        void Delete(int id);

        void Modify(int id, ModifyRestaurantDto dto);
    }
}