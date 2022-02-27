using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;
using System.Linq;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        public int Create(int restaurantId, CreateDishDto dto);
    }

    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public int Create(int restaurantId, CreateDishDto dto)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            var dishEntity = _mapper.Map<Dish>(dto);
            _dbContext.Dishes.Add(dishEntity);
            _dbContext.SaveChanges();

            return dishEntity.Id;
        }
    }
}
