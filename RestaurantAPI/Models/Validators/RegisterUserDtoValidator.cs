using FluentValidation;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Linq;

namespace RestaurantAPI.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly RestaurantDbContext _dbContext;

        public RegisterUserDtoValidator(RestaurantDbContext dbContext)
        {
            this._dbContext = dbContext;
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password).MinimumLength(7);
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) => 
                {
                var emailInUse = _dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
            
        }
        
    }
}
