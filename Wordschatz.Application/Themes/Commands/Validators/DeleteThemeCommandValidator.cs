using FluentValidation;
using System.Data;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Themes.Commands.Validators
{
    public class DeleteThemeCommandValidator : AbstractValidator<DeleteThemeCommand>
    {
        public DeleteThemeCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(command => command.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1);
        }
    }
}