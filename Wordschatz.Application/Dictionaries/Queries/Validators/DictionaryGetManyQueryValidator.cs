using FluentValidation;

namespace Wordschatz.Application.Dictionaries.Queries.Validators
{
    class DictionaryGetManyQueryValidator : AbstractValidator<DictionaryGetManyQuery>
    {
        public DictionaryGetManyQueryValidator()
        {
            RuleFor(x => x.Amount)
                .InclusiveBetween(1,500).WithMessage("The amount of dictionaries being queries must be between 1 and 500.");

            RuleFor(x => x.PageNum)
                .GreaterThanOrEqualTo(1).WithMessage("The page number must be positive and not zero.");
        }
    }
}
