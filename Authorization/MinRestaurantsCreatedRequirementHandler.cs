using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Entities;
using RestaurantAPI.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantAPI.Authorization
{
    public class MinRestaurantsCreatedRequirementHandler : AuthorizationHandler<MinRestaurantsCreatedRequirement>
    {
        private readonly ILogger<MinRestaurantsCreatedRequirementHandler> _logger;
        private readonly RestaurantDbContext _restaurantDbContext;

        public MinRestaurantsCreatedRequirementHandler(ILogger<MinRestaurantsCreatedRequirementHandler> logger, RestaurantDbContext restaurantDbContext)
        {
            this._logger = logger;
            this._restaurantDbContext = restaurantDbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinRestaurantsCreatedRequirement requirement)
        {
            int userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            int createdRestaurantsCount = _restaurantDbContext.Restaurants.Count(r => r.CreatedById == userId);

            if(createdRestaurantsCount >= requirement.MinimumRestaurantsCreated)
            {
                _logger.LogInformation($"User has enough restaurants to check all restaurants.");
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation($"Unfortunetly user didn't create at least two restaurants.");
            }
            
            return Task.CompletedTask;
        }
    }
}
