using FluentValidation;

namespace Wordschatz.Application.Themes.Commands.Validators
{
    public class CreateThemeCommandValidator : AbstractValidator<CreateThemeCommand>
    {
        public CreateThemeCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(command => command.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.ParentId)
                .GreaterThanOrEqualTo(1).When(command => command.ParentId != null);
        }
    }
}