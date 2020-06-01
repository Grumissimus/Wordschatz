using FluentValidation;

namespace Wordschatz.Application.Themes.Commands.Validators
{
    public class CreateThemeCommandValidator : AbstractValidator<CreateThemeCommand>
    {
        public CreateThemeCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the dictionary must be a positive non-zero number."); ;

            RuleFor(command => command.Name)
                .NotNull().WithMessage("The name of the theme cannot be null.")
                .NotEmpty().WithMessage("The theme must have a name.");

            RuleFor(command => command.ParentId)
                .GreaterThanOrEqualTo(1)
                .When(command => command.ParentId != null)
                .WithMessage("The identifier of the parent theme must be a positive non-zero number.");
        }
    }
}