using FluentValidation;

namespace Wordschatz.Application.Themes.Queries.Validators
{
    class ThemeGetManyQueryValidator : AbstractValidator<ThemeGetManyQuery>
    {
        public ThemeGetManyQueryValidator()
        {
            RuleFor(x => x.Amount)
                .NotNull()
                .InclusiveBetween(1, 500);

            RuleFor(x => x.Amount)
                .NotNull()
                .GreaterThanOrEqualTo(1);
        }
    }
}
