using FluentValidation;

namespace Wordschatz.Application.Themes.Commands.Validators
{
    public class DeleteThemeCommandValidator : AbstractValidator<DeleteThemeCommand>
    {
        public DeleteThemeCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .NotNull()
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the dictionary must be a positive non-zero number.");

            RuleFor(command => command.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the theme must be a positive non-zero number.");
        }
    }
}