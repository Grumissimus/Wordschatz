using FluentValidation;

namespace Wordschatz.Application.Words.Commands.Validators
{
    internal class DeleteWordCommandValidator : AbstractValidator<DeleteWordCommand>
    {
        public DeleteWordCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The dictionary identifier must be a positive non-zero integer.");

            RuleFor(command => command.ThemeId)
                .GreaterThanOrEqualTo(1).WithMessage("The theme identifier must be a positive non-zero integer.");

            RuleFor(command => command.Id)
                .GreaterThanOrEqualTo(1).WithMessage("The word identifier must be a positive non-zero integer.");
        }
    }
}