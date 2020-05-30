using FluentValidation;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Commands.Validators
{
    public class EditDictionaryCommandValidator : AbstractValidator<EditDictionaryCommand>
    {
        public EditDictionaryCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the dictionary must be a positive non-zero number.");

            RuleFor(command => command.Name)
                .NotNull().WithMessage("The name of the dictionary cannot be null.")
                .NotEmpty().WithMessage("The dictionary must have a name.");

            RuleFor(command => command.Description)
                .NotNull().WithMessage("The description of the dictionary cannot be null.");

            RuleFor(command => command.Password)
                .NotNull().WithMessage("The password cannot be null.").When(command => command.VisibilityLevel == Visibility.PasswordProtected)
                .NotEmpty().WithMessage("The dictionary with password-protected visibility level must have a password.").When(command => command.VisibilityLevel == Visibility.PasswordProtected);
        }
    }
}