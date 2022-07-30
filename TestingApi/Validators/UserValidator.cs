using FluentValidation;
using TestingApi.Models.Domain;

namespace TestingApi.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please specify a last name");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please specify a first name");
        }
    }
}
