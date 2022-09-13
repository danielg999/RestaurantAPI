using FluentValidation;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Linq;

namespace RestaurantAPI.Validators
{
    public class RestaurantQueryValitator : AbstractValidator<RestaurantQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };
        private string[] allowedSortByColumNames = { nameof(Restaurant.Name), nameof(Restaurant.Description), nameof(Restaurant.Category) };
        public RestaurantQueryValitator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
                }
            });

            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumNames.Contains(value))
                .WithMessage($"Sort by is optional or must be in [{string.Join(",", allowedSortByColumNames)}]");
        }
    }
}
