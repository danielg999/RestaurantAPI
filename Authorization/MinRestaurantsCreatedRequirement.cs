using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class MinRestaurantsCreatedRequirement : IAuthorizationRequirement
    {
        public int MinimumRestaurantsCreated { get; set; }
        public MinRestaurantsCreatedRequirement(int minimumRestaurantsCreated)
        {
            this.MinimumRestaurantsCreated = minimumRestaurantsCreated;
        }
    }
}