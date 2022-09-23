using Domain.Entities;
using FluentValidation;

namespace Services;

public class LessonValidator : AbstractValidator<Lesson>
{
    public LessonValidator()
    {
        RuleFor(l => l.Title)
            .NotEmpty().WithMessage("Um Título deve ser informado!")
            .MinimumLength(2).WithMessage("O Título deve ter no mínimo 2 caracteres.")
            .MaximumLength(140).WithMessage("O Título deve ter no máximo 140 caracteres.");
        
        RuleFor(l => l.Link)
            .NotEmpty().WithMessage("Um link deve ser informado.")
            .MinimumLength(8).WithMessage("O link deve ter no mínimo 8 caracteres.")
            .MaximumLength(240).WithMessage("O link deve ter no máximo 240 caracteres.");

        RuleFor(l => l.Description)
            .NotEmpty().WithMessage("Uma Descrição deve ser informada!")
            .MinimumLength(2).WithMessage("A descrição deve ter no mínimo 2 caracteres.")
            .MaximumLength(240).WithMessage("A descrição deve ter no máximo 240 caracteres.");

        RuleFor(l => l.Order)
            .NotEmpty().WithMessage("A ordem da aula deve ser informada! (um número)");
    }
    
}