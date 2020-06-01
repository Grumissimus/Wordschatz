using FluentValidation;

namespace Wordschatz.Application.Themes.Queries.Validators
{
    class ThemeGetManyQueryValidator : AbstractValidator<ThemeGetManyQuery>
    {
        public ThemeGetManyQueryValidator()
        {
            RuleFor(x => x.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The identifier of dictionary must be positive and not zero.");

            RuleFor(x => x.Amount)
                .InclusiveBetween(1, 500).WithMessage("The amount of dictionaries being queries must be between 1 and 500.");

            RuleFor(x => x.PageNum)
                .GreaterThanOrEqualTo(1).WithMessage("The page number must be positive and not zero.");
        }
    }
}
