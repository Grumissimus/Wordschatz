using FluentValidation;

namespace Wordschatz.Application.Themes.Queries.Validators
{
    class ThemesGetByIdQueryValidator : AbstractValidator<ThemeGetByIdQuery>
    {
        public ThemesGetByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("The theme's identifier must be positive and not zero.");

            RuleFor(x => x.DictionaryId)
                .GreaterThanOrEqualTo(1).WithMessage("The dictionary's identifier must be positive and not zero.");
        }
    }
}
