using FluentValidation;

namespace Wordschatz.Application.Marks.Commands.Validators
{
    public class ChangeMarkCommandValidator : AbstractValidator<ChangeMarkCommand>
    {
        public ChangeMarkCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotNull().WithMessage("The name of the theme cannot be null.")
                .NotEmpty().WithMessage("The theme must have a name.");

            RuleFor(command => command.DictionaryId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("The identifier of the dictionary must be a positive non-zero number.");
        }
    }
}