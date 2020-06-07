using FluentValidation;

namespace Wordschatz.Application.Marks.Commands.Validators
{
    public class DeleteMarkCommandValidator : AbstractValidator<DeleteMarkCommand>
    {
        public DeleteMarkCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .NotNull()
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the dictionary must be a positive non-zero number.");

            RuleFor(command => command.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the mark must be a positive non-zero number.");
        }
    }
}