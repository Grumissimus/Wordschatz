using FluentValidation;
using System.Data;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Themes.Commands.Validators
{
    public class EditThemeCommandValidator : AbstractValidator<EditThemeCommand>
    {
        public EditThemeCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.ParentId)
                .GreaterThanOrEqualTo(1).When(command => command.ParentId != null);
        }
    }
}