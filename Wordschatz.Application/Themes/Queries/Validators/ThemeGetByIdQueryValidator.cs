using FluentValidation;

namespace Wordschatz.Application.Themes.Queries.Validators
{
    class ThemesGetByIdQueryValidator : AbstractValidator<ThemeGetByIdQuery>
    {
        public ThemesGetByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1);
        }
    }
}
