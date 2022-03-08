using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto, int userId);
        RestaurantDto GetById(int id);
        IEnumerable<RestaurantDto> GetAll();

        void Delete(int id, ClaimsPrincipal user);

        void Modify(int id, ModifyRestaurantDto dto, ClaimsPrincipal user);
    }
}