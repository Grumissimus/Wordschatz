using FluentValidation;

namespace Wordschatz.Application.Words.Queries.Validators
{
    public class GetManyWordsQueryValidator : AbstractValidator<GetManyWordsQuery>
    {
        public GetManyWordsQueryValidator()
        {
            RuleFor(query => query.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the dictionary must be a positive non-zero number.");

            RuleFor(query => query.ThemeId)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of the theme must be a positive non-zero number.");

            RuleFor(query => query.Amount)
                .InclusiveBetween(1, 500).WithMessage("The amount of words being fetched must be between 1 and 500.");

            RuleFor(query => query.PageNum)
                .GreaterThanOrEqualTo(1).WithMessage("The page number must be positive and not zero.");
        }
    }
}