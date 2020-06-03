using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Application.Dictionaries.Commands.Validators
{
    public class AddMarkToDictionaryCommandValidator : AbstractValidator<AddMarkToDictionaryCommand>
    {
        public AddMarkToDictionaryCommandValidator()
        {
            RuleFor(command => command.MarkId)
                .NotNull().WithMessage("The mark identifier cannot be null.")
                .GreaterThanOrEqualTo(1).WithMessage("The mark identifier must be a positive non-zero number.");

            RuleFor(command => command.DictionaryId)
                .NotNull().WithMessage("The dictionary identifier cannot be null.")
                .GreaterThanOrEqualTo(1).WithMessage("The dictionary identifier must be a positive non-zero number.");
        }
    }
}
