using Domain.Entities;
using FluentValidation;

namespace Services;

public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage("Um Título deve ser informado")
            .MaximumLength(140).WithMessage("O Título deve ter no máximo 140 caracteres.");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Uma Descrição deve ser informada!")
            .MaximumLength(240).WithMessage("A descrição deve ter no máximo 240 caracteres.");
    }
}