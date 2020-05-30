using FluentValidation;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Commands.Validators
{
    public class EditDictionaryCommandValidator : AbstractValidator<EditDictionaryCommand>
    {
        public EditDictionaryCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(command => command.Name)
                .NotNull();

            RuleFor(command => command.Description)
                .NotNull();

            RuleFor(command => command.Password)
                .NotNull()
                .NotEmpty()
                .When(command => command.VisibilityLevel == Visibility.PasswordProtected);
        }
    }
}