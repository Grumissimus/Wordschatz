using FluentValidation;

namespace Wordschatz.Application.Dictionaries.Queries.Validators
{
    class DictionaryGetByIdQueryValidator : AbstractValidator<DictionaryGetByIdQuery>
    {
        public DictionaryGetByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThanOrEqualTo(1);
        }
    }
}
