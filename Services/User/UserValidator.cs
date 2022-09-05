using Domain.Entities;
using FluentValidation;

namespace Services;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty();

        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(u => u.Password)
            .NotNull()
            .MinimumLength(4);

        RuleFor(u => u.Role)
            .NotNull();
    }
}
