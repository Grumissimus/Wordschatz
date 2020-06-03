using FluentValidation;

namespace Wordschatz.Application.Themes.Commands.Validators
{
    public class EditThemeCommandValidator : AbstractValidator<EditThemeCommand>
    {
        public EditThemeCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotNull().WithMessage("The name of the theme cannot be null.")
                .NotEmpty().WithMessage("The theme must have a name.");

            RuleFor(command => command.ParentId)
                .GreaterThanOrEqualTo(1).When(command => command.ParentId != null)
                .WithMessage("The identifier of the dictionary must be a positive non-zero number.");
        }
    }
}