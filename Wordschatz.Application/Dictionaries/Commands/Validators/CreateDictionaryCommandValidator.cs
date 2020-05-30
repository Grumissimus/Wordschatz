using FluentValidation;
using System.Data;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Commands.Validators
{
    public class CreateDictionaryCommandValidator : AbstractValidator<CreateDictionaryCommand>
    {
        public CreateDictionaryCommandValidator()
        {
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