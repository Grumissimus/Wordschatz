using FluentValidation;

namespace Wordschatz.Application.Words.Queries.Validators
{
    public class GetWordByIdQueryValidator : AbstractValidator<GetWordByIdQuery>
    {
        public GetWordByIdQueryValidator()
        {
            RuleFor(command => command.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the dictionary must be a positive non-zero number.");

            RuleFor(command => command.ThemeId)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the theme must be a positive non-zero number.");

            RuleFor(command => command.Id)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the word must be a positive non-zero number.");
        }
    }
}