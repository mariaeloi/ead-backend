using Domain.Entities;
using FluentValidation;

namespace Services;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Nome deve ser informado");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("E-mail deve ser informado")
            .EmailAddress().WithMessage("Formato de e-mail inválido");

        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Nome de usuário deve ser informado")
            .MinimumLength(2).WithMessage("Nome de usuário deve ser maior ou igual a 2 caracteres")
            .Matches("^[a-zA-Z0-9._]+$").WithMessage("Formato de nome de usuário inválido");

        RuleFor(u => u.Password)
            .NotNull().WithMessage("Senha deve ser informada")
            .MinimumLength(4).WithMessage("Senha deve ser maior ou igual a 4 caracteres");
    }
}
