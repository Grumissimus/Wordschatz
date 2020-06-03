﻿using FluentValidation;

namespace Wordschatz.Application.Words.Commands.Validators
{
    internal class ChangeWordCommandValidator : AbstractValidator<ChangeWordCommand>
    {
        public ChangeWordCommandValidator()
        {
            RuleFor(command => command.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The dictionary identifier must be a positive non-zero integer.");

            RuleFor(command => command.ThemeId)
                .GreaterThanOrEqualTo(1).WithMessage("The theme identifier must be a positive non-zero integer.");

            RuleFor(command => command.Id)
                .GreaterThanOrEqualTo(1).WithMessage("The word identifier must be a positive non-zero integer.");

            RuleFor(x => x.Term)
                .NotNull().WithMessage("The term cannot be null.")
                .NotEmpty().WithMessage("The term field is required.");

            RuleFor(x => x.Meaning)
                .NotNull().WithMessage("The meaning cannot be null.")
                .NotEmpty().WithMessage("The meaning field is required.");
        }
    }
}