using FluentValidation;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Commands.Validators
{
    public class DeleteDictionaryCommandValidator : AbstractValidator<DeleteDictionaryCommand>
    {
        public DeleteDictionaryCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1);
        }
    }
}