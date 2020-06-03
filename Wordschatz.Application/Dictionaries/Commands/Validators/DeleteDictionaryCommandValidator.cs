using FluentValidation;

namespace Wordschatz.Application.Dictionaries.Commands.Validators
{
    public class DeleteDictionaryCommandValidator : AbstractValidator<DeleteDictionaryCommand>
    {
        public DeleteDictionaryCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotNull().WithMessage("The identifier of the dictionary cannot be null.")
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the dictionary must be a positive non-zero number.");
        }
    }
}