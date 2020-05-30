using FluentValidation;

namespace Wordschatz.Application.Dictionaries.Queries.Validators
{
    class DictionaryGetManyQueryValidator : AbstractValidator<DictionaryGetManyQuery>
    {
        public DictionaryGetManyQueryValidator()
        {
            RuleFor(x => x.Amount)
                .NotNull()
                .InclusiveBetween(1,500);

            RuleFor(x => x.Amount)
                .NotNull()
                .GreaterThanOrEqualTo(1);
        }
    }
}
